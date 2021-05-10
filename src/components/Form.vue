<template>
<header>
    <h1> Login </h1>
    <form @submit="onSubmit" class="form">
        <div>
            <label>Username ->  </label>
            <input
                type = "text"
                v-model="Username"
                name = "Username"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Password ->  </label>
            <input
                type = "text"
                name = "Password"
                v-model="Password"
                placeholder = "Enter..."
            />
        </div>
        <input type = "submit" value="LOGIN"/>
    </form>

    
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
</style>