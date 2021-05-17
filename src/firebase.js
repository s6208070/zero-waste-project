import firebase from 'firebase'

const firebaseConfig = {
  apiKey: "AIzaSyADr89Q1Bqb-X3Fi_9cDq-W-QHAqKtAHP4",
  authDomain: "zero-waste-d97bf.firebaseapp.com",
  databaseURL: "https://zero-waste-d97bf-default-rtdb.asia-southeast1.firebasedatabase.app",
  projectId: "zero-waste-d97bf",
  storageBucket: "zero-waste-d97bf.appspot.com",
  messagingSenderId: "174775595809",
  appId: "1:174775595809:web:7613b285e7563dd6e88460"
};
const firebaseApp = firebase.initializeApp(firebaseConfig);
const auth = firebase.auth()
auth.setPersistence(firebase.auth.Auth.Persistence.LOCAL)

export const STR = firebaseApp.storage()

export const RTDB = firebaseApp.database()
