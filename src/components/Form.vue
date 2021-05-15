<template>
<header>
    <v-card flat align = "center" class = "pt-12 pb-0" color = "transparent">
    <v-card
        max-width = "500"
        align = "center"
        class = "py-7 ma-0 rounded-lg"
    >
        <h1> {{this.name}} </h1>
        <div class = "smol"></div>

        <v-form class="form">
            <v-container class = "pa-0 ma-0">
                <v-row justify = "center" style = "height : 60px;">
                    <v-col cols = "8">
                        <v-text-field
                            type = "text"
                            label = "Username"
                            v-model ="Username"
                            required
                        ></v-text-field>
                    </v-col>
                </v-row>

                <v-row justify = "center" style = "height : 100px;">
                    <v-col cols = "8">
                        <v-text-field
                            type = "password"
                            label = "Password"
                            v-model ="Password"
                            required
                        ></v-text-field>
                    </v-col>
                </v-row>

                <v-btn 
                    @click="onSubmit"
                    dark
                    rounded
                    class = "purple darken-3 font-weight-medium"
                >{{this.name2}}</v-btn>
            </v-container>
        </v-form>
    </v-card>   
    </v-card>
</header>
</template>

<script>
export default {
    name: "Form",
    data() {
      return{
        Username: "",
        Password: "",
      }
    },
    props:{
        name: {type:String},
        name2: {type:String},
    },
    methods:{
        onSubmit(e){
            e.preventDefault();
            if(!this.Username){
                alert('Please enter your username'); return;
            }if(!this.Password){
                alert('Please enter your password'); return;
            }
            const request = {
                Username: this.Username,
                Password: this.Password,
            }
            this.$emit('login-request', request)

            this.Username=''
            this.Password=''
        }
    }
}
</script>
<style>
 .form {
     align-items: center;
     align-content: center;
     text-align: center;
 }

 .smol {
    width: 80px;
    height: 5px;
    background: #861CA7;
    margin-top: 7px;
  }
</style>