import firebase from 'firebase'
import { ref, onUnmounted } from '@vue/composition-api'


const firebaseConfig = {
  apiKey: "AIzaSyADr89Q1Bqb-X3Fi_9cDq-W-QHAqKtAHP4",
  authDomain: "zero-waste-d97bf.firebaseapp.com",
  projectId: "zero-waste-d97bf",
  storageBucket: "zero-waste-d97bf.appspot.com",
  messagingSenderId: "174775595809",
  appId: "1:174775595809:web:7613b285e7563dd6e88460"
};
const firebaseApp = firebase.initializeApp(firebaseConfig);
const db = firebaseApp.firestore()
const garbagesCollection = db.collection('garbages')
const auth = firebase.auth()
auth.setPersistence(firebase.auth.Auth.Persistence.LOCAL)

export const DB = firebaseApp.firestore().collection("garbages")
export const STR = firebaseApp.storage()

export const createGarbage = (garbage) => {
  return garbagesCollection.add(garbage)
}

export const getGarbage = async (id) => {
  const garbage = await garbagesCollection.doc(id).get()
  return garbage.exist ? garbage.data() : null
}

export const updateGarbage = (id, garbage) => {
  return garbagesCollection.doc(id).update(garbage)
}

export const deleteGarbage = (id) => {
  return garbagesCollection.doc(id).delete()
}

export const useLoadGarbages = () => {
  const garbages = ref([])
  const close = garbagesCollection.onSnapshot(snapshot => {
    garbages.value = snapshot.docs.map(doc => ({ id: doc.id, ...doc.data() }))
  })
  onUnmounted(close)
  return garbages
}