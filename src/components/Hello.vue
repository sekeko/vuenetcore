<template>
  
   <div id="center">
      Email
      <input style="float: right;"type="text" name="email"><br><br>
      Password
      <input style="float: right;" type="password" name="password"><br><br>
      <button onclick="login">Login</button>
  </div>  
</template>

<script>
export default {
  data  () {
    return {}
  },
  methods: {
    login () {
      this.$router.replace('/api/hello')
      alert('hello you are login')
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
