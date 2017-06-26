<template>
  
   <div id="center">
      Email
      <input style="float: right; " v-model="email"type="text" name="email"><br><br>
      Password
      <input style="float: right;" v-model="password" type="password" name="password"><br><br>
      <button v-on:click="login">Login</button>
  </div>  
</template>

<script>
export default {
  data  () {
    return {email: '',
      password: ''}
  },
  methods: {
    login () {
        // this.$router.replace('/api/login')
      var createHash = require('sha.js')
      var sha256 = createHash('sha256')
      var passwordEncrypt = sha256.update(this.password, 'utf8').digest('hex')
      passwordEncrypt = passwordEncrypt.toUpperCase()
      var inputData = {'UserEmail': this.email,
        'UserPassword': passwordEncrypt
      }
      this.$http.get('http://localhost:5000/api/Login', inputData).then(function (result) {
        var response = result.body
        if (response === 'true') {
          alert('Welcome your are loged')
          this.$router.push('/Home')
        }
      },
        function (result) {
        })
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
#center {
  background-color:rgb(240,240,240);
  height:20%;width:250px; 
  position: absolute;top:35%;right:40%;
  text-align:left;
  padding:5px;
  
}
</style>
