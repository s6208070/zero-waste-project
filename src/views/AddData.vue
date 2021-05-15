<template>
  <v-app style = "overflow:auto;">
    <Navbar/>
    <v-main>
      <h1> Add garbage data</h1>
      <form @submit="addTask" class="form" name="form">
        <div>
            <label>Province<br> </label>
            <input
                type = "text"
                v-model="DATA.province"
                name = "Province"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Amphoe <br> </label>
            <input
                type = "text"
                name = "Amphoe"
                v-model="DATA.amphoe"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Tambon <br>  </label>
            <input
                type = "text"
                name = "Tambon"
                v-model="DATA.tambon"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Timestamp<br> </label>
            <input
                type = "datetime-local"
                v-model="DATA.timestamp"
                name = "Timestamp"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Coordinate<br> </label>
            <input
                type = "number"
                v-model="DATA.cox"
                step = "0.000001"
                name = "CoX"
                placeholder = "Enter X..."
            />
            <input
                type = "number"
                v-model="DATA.coy"
                step = "0.000001"
                name = "CoY"
                placeholder = "Enter Y..."
            />
        </div>
        <div>
            <label>User ID<br> </label>
            <input
                type = "text"
                v-model="DATA.userid"
                name = "UserID"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Weight<br> </label>
            <input
                type = "number"
                v-model="DATA.weight"
                step = "0.01"
                name = "Weight"
                placeholder = "Enter..."
            />
        </div>
        <div>
          <label> Description<br> </label>
          <textarea 
            rows="4" 
            cols="50" 
            name="comment"
            v-model="DATA.description" 
            form="form"
            placeholder = "Enter..."
          ></textarea>
        </div>
        <input type ="file" @change="fileChange"/> <br>
        <img :src="previewurl"/>
        

        <input type = "submit"/>
    </form>
    </v-main>
  </v-app>
</template>
<script>
import Navbar from '@/components/Navbar'
export default {
  components: { Navbar },
  name: 'Search',
  data() {
      return{
        DATA: {
            id: "",
            timestamp: "",
            province: "",
            amphoe: "",
            tambon: "",
            cox: "",
            coy: "",
            userid: "",
            weight: "",
            status: "Not collected",
            base64img: "not assigned",
            description: "",
        },
        selectedfile: null,
        previewurl: null,
      }
    },
  methods: {
    async addTask(e){
      e.preventDefault()
      const res = await fetch("api/garbages", {
          method: 'POST',
          headers: {
              'Content-type': 'application/json', 
          },
          body: JSON.stringify(this.DATA),
      })
      res.json()
      alert("Successfully add the gargbage information. Please go back to the Search page or GarbageData page")
      this.DATA = {
            id: "",
            timestamp: "",
            province: "",
            amphoe: "",
            tambon: "",
            cox: "",
            coy: "",
            userid: "",
            weight: "",
            status: "Not collected",
            base64img: "not assigned",
            description: "",
        }
        this.selectedfile = null
        this.previewurl = null
    },
    
    async fileChange(e){
      this.selectedfile = e.target.files[0];
      if(this.selectedfile == null) return;
      this.previewurl = URL.createObjectURL(this.selectedfile);
      const reader = new FileReader()
      reader.addEventListener("load", function () {
        this.DATA.base64img = reader.result;
      }.bind(this), false);
      if(this.selectedfile){
        reader.readAsDataURL(this.selectedfile)
      } 
    },
  }, 

}
</script>