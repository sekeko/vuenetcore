<template>
     <div id="bodyright">   
         <h1>Welcome</h1>  
         <button v-on:click="logout">Logout</button> 
  </div>
 </template>

<script>
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#bodyleft{
     background-color:white;
  height:10%;width:480px; 
  position: absolute;top:2%;left:3%;
   text-align:left;
}
  td{
     border: 1px solid black;

}
 td > input{
     border: 0px solid green;
     width:100%
}
#row1{
    width:40%;
    background-color:rgb(255,200,0);
}
#rightfloting{
    float:right;
    margin:5%;
}
#bodyright{
     background-color:green;
  height:75%;width:400px; 
  position: absolute;top:2%;right:3%;
   text-align:right;
}
#bottonL{
   padding: 8px 20px;
}
#bottonLFright{
    padding: 8px 20px;
     float:right
}
#bodycenter{
  background-color:white;
  height:70%;width:480px; 
  position: absolute;top:15%;left:5%;
  text-align:left; 
}

</style>
