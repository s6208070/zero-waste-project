<template>
<header>
    <v-card flat align = "center" class = "pt-12 pb-0" color = "transparent">
    <v-card
        max-width = "450"
        align = "center"
        class = "pt-10 pb-8 ma-0 rounded-xl"
    >
        <h1> {{this.name}} </h1>
        <div class = "smol"></div>

        <v-form class="form" @submit="onSubmit" lazy-validation v-model="valid" ref="form">
            <v-container class = "pt-4 ma-0">
                <v-row justify = "center" style = "height : 70px;">
                    <v-icon large>mdi-account-circle</v-icon>
                    <v-col cols = "8">    
                        <v-text-field
                            type = "text"
                            label = "Username"
                            v-model ="Username"
                            :rules = "userRules"
                            required
                        ></v-text-field>
                    </v-col>
                </v-row>

                <v-row v-show = "this.name == 'Register'" justify = "center" style = "height : 70px;">
                    <v-icon large>mdi-key</v-icon>
                    <v-col cols = "8">
                        <v-text-field
                            type = "password"
                            label = "Password"
                            :rules = "passwordRules"
                            v-model ="Firstpass"
                        ></v-text-field>
                    </v-col>
                </v-row>

                <v-row justify = "center" style = "height : 100px;">
                    <v-icon large>mdi-key</v-icon>
                    <v-col cols = "8">
                        <v-text-field
                            type = "password"
                            :label = "[this.name == 'Register' ? 'Confirm Password' : 'Password']"
                            :rules = "confirmRules" 
                            v-model ="Password"
                        ></v-text-field>
                    </v-col>
                </v-row>

                <v-expand-transition>
                <v-row v-show = "valid" justify = "center" style = "height : 60px;">
                    <v-col cols = "10">
                    <v-btn 
                        type = "submit"
                        dark
                        rounded
                        class = "font-weight-medium"
                        block
                    >{{this.name2}}</v-btn>
                    </v-col>
                </v-row>
                </v-expand-transition>
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
        valid: true,
        Username: "",
        Password: "",
        Firstpass: "",
      }
    },
    props:{
        name: {type:String},
        name2: {type:String},
    },
    methods:{
        onSubmit(e){
            this.$refs.form.validate();
            e.preventDefault();
            if(!this.Username){
                alert('Please enter your username'); return;
            }if(!this.Password){
                alert('Please enter your password'); return;
            }
            const request = {
                Username: this.Username,
                Firstpass: this.Firstpass,
                Password: this.Password,
            }
            this.$emit('login-request', request)

            // this.Username=''
            // this.Password=''
            // this.Firstpass=''
        },
    },
    computed:{
        userRules() {
            const userRules = [
            v => !!v || "E-mail is required",
            v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
            ]
            return userRules
        },

        passwordRules() {
            const passwordRules = [
            v => !!v || "Password is required",
            v => (v && v.length >= 6) || "Password should have more than 6 characters",
            ]
            return passwordRules
        },

        confirmRules() {
            const passwordRules = [
            v => !!v || "Password is required",
            v => (v && v.length >= 6) || "Password should have more than 6 characters",
            ]

            const confirmRules = [v => !!v || "Password confirmation is required",]
            if(this.Firstpass){
                const cond1 = 
                v => (!!v && v) === this.Firstpass || "Password does not match"
                confirmRules.push(cond1)
            }

            if(this.name == "Register"){
                return confirmRules
            }
            else{
                return passwordRules
            }
        },
    },
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