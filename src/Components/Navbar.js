
import { Logout } from '@mui/icons-material';
import { Avatar, Dialog, DialogActions, DialogContent, DialogTitle, IconButton, Tooltip } from '@mui/material';
import { GoogleLogin, GoogleOAuthProvider } from '@react-oauth/google';
import axios from 'axios';
import jwt_decode from 'jwt-decode';
import React, { useEffect, useState } from 'react'
import {  useNavigate } from 'react-router-dom';
import { Button } from 'semantic-ui-react';

// const CLIENT_ID = "206986272307-ansblv81ksjd6p43mmdh17lon8t64bdf.apps.googleusercontent.com";
// const SCOPES = 'https://www.googleapis.com/auth/drive.file';


function Navbar() {
  // const newClientID="479823657020-dpchjf6bvol7qirr7hlfrvjcjf32hahq.apps.googleusercontent.com" 
  
 const initialValues={
    username:"",
    password:"",
   
  }

  const [loginuser,setloginUser]=useState(initialValues);
  const [user,setUser]=useState(null);
  const[registerForm,setregisterForm]=useState();
  const [open, setOpen] = useState(false);
    const navigate=useNavigate();
    let base64s="";


  useEffect(()=>{

    const jwt = localStorage.getItem("currentUser");
    if(jwt){
      const [header, payload, signature] = jwt.split('.');
      const decodedPayload = JSON.parse(atob(payload));
      const userId = decodedPayload.nameid;
      setUser(userId);
    }

    },[]);



    const handleLoginSuccess = (response) => {
      debugger
      const details=jwt_decode(response.credential)
      console.log(details)
      const users={
        userName:details.name,
        image:"string",
        userEmail:details.email,
        userPassword:"Google Login",
        roleId:2,
        userAddress:'google'
      }

      axios.post("https://localhost:7192/api/Register/Google",users).then((res)=>{
        console.log(res.data)
        localStorage.setItem("currentUser",JSON.stringify(res.data));
       
      }).catch((e)=>{
      alert(e)
      })

  
    };
    

const changeHand=(event)=>{
setloginUser({...loginuser,[event.target.name]:event.target.value});
  }


const  changeHandler=(event)=>{

setregisterForm({...registerForm,[event.target.name]:event.target.value})
console.log(registerForm)

}


 const login=()=>{
  debugger
 axios.post("https://localhost:7192/api/Account/authenticate",loginuser).then((res)=>{
  localStorage.setItem("currentUser",JSON.stringify(res.data));
 setOpen(true);
 }).catch((e)=>{
  alert(e);
 })

};


const registerClick=()=>{
console.log(registerForm)
registerForm.roleId=2;
axios.post("https://localhost:7192/api/Register",registerForm).then((res)=>{
  setregisterForm(res)
}).catch((e)=>{
  alert(e);
})
}

const avatarClick = () => {
if(user){
  navigate("/profile",{state:user});
}
};


const logOut=()=>{

localStorage.clear();


}

const fileSelect=(e)=>{
  
  var files=e.target.files;
   var file=files[0];
   if(file&&files){
    var reader=new FileReader();
    reader.onload=handleReader.bind(this);
      reader.readAsBinaryString(file);
   } 
}

const handleReader=(file)=>{

  var binaryString=file.target.result;
  base64s=btoa(binaryString);
 let pic="data:image/png;base64,"+base64s;
   registerForm.image=pic;

}


  return (
<div>
<div className="navbar">
     
        <Avatar onClick={avatarClick} sx={{ width: 56, height: 56, bgcolor: "grey" }}>
        </Avatar>
  
   
   

        <nav>
          {
            user? null:  <button data-toggle="modal" data-target="#register">Register</button>
          }
          {
            user?(<div>
         
              <Tooltip title="Logout">
          <IconButton onClick={logOut}>
       <Logout/>
            </IconButton>
              </Tooltip>

            </div>
          ):<div className='row'>
        
              <button  data-toggle="modal" data-target="#login">Login</button>
              <GoogleOAuthProvider clientId="479823657020-dpchjf6bvol7qirr7hlfrvjcjf32hahq.apps.googleusercontent.com">
   
      <GoogleLogin auto_select="false" text="signin" width="50px" shape="circle" onSuccess={handleLoginSuccess} 
    onError={() => {
    console.log('Login Failed');
        }} />
  
</GoogleOAuthProvider>
          </div>
           
           
          }





      </nav>
    
      </div>



     

      <form>
  <div className='modal' id='login' role="dialog" >
    <div className='modal-dialog'>
      <div className='modal-content'>
        {/* -------------HEADER-------------- */}
        <div className='modal-header'>
          <div className='modal-title text-primary'>Login</div>
          <button className='close' data-dismiss="modal" ><span>&times;</span></button>
        </div>
        {/* ---------------------BODY-------------- */}
        <div className='modal-body'>
          <div className='form-group row'>
            <label className='col-sm-4' for='txtname'>UserName</label>
            <div className='col-sm-8'>
              <input type="text"  onChange={changeHand} value={loginuser.username}
               placeholder='Enter user Name'  id='txtname' name='username' className='form-control'/>
            </div>
          </div>   

          <div className='form-group row'>
            <label className='col-sm-4' for='txtpass'>Password</label>
            <div className='col-sm-8'>
              <input type="password" onChange={changeHand} value={loginuser.password}
               placeholder='Enter password'  id='txtpass' name='password' className='form-control'/>
            </div>
          </div>

        </div>
        {/* --------------------FOOTER---------------- */}
        <div className='modal-footer'>
          <button className='btn btn-success' onClick={login} data-dismiss="modal" >Login</button>
          <button className='btn btn-danger' onfocus="this.value=''" >Cancel</button>
        </div>
      </div>
    </div>
  </div>

</form> 


<form>
  <div className='modal' id='register' role="dialog">
    <div className='modal-dialog'>
      <div className='modal-content'>
        {/* -------------HEADER-------------- */}
        <div className='modal-header'>
          <div className='modal-title text-primary'>Register</div>
          <button className='close' data-dismiss="modal" ><span>&times;</span></button>
        </div>
        {/* ---------------------BODY-------------- */}
        <div className='modal-body'>
          <div className='form-group row'>
            <label className='col-sm-4' for='txtname'>UserName</label>
            <div className='col-sm-8'>
              <input type="text"  onChange={changeHandler} 
               placeholder='Enter user Name'  id='txtname' name='userName' className='form-control'/>
            </div>
          </div>   

          <div className='form-group row'>
            <label className='col-sm-4' for='txtemail'>UserEmail</label>
            <div className='col-sm-8'>
              <input type="email"  onChange={changeHandler} 
               placeholder='Enter Email'  id='txtemail' name='userEmail' className='form-control'/>
            </div>
          </div>
          <div className='form-group row'>
            <label className='col-sm-4' for='yxtaddress'>UserAddress</label>
            <div className='col-sm-8'>
              <input type="text"  onChange={changeHandler} 
               placeholder='Enter Address'  id='yxtaddress' name='userAddress' className='form-control'/>
            </div>
          </div>

          <div className='form-group row'>
            <label className='col-sm-4' for='txtimage'>UserImage</label>
            <div className='col-sm-8'>
            <input type="file"  onChange={fileSelect}  name="image" class="form-control" id="txtimg" />
            </div>
          </div>

          <div className='form-group row'>
            <label className='col-sm-4' for='txtpass'>UserPassword</label>
            <div className='col-sm-8'>
              <input type="password" onChange={changeHandler} 
               placeholder='Enter password'  id='txtpass' name='userPassword' className='form-control'/>
            </div>
          </div>
        </div>
        {/* --------------------FOOTER---------------- */}
        <div className='modal-footer'>
          <button className='btn btn-success' onClick={registerClick}>Register</button>
          <button className='btn btn-danger' onfocus="this.value=''" >Cancel</button>
        </div>
      </div>
    </div>
  </div>

</form> 

<Dialog open={open} onClose={() => setOpen(false)}>
        <DialogTitle>Welcome!</DialogTitle>
        <DialogContent>
          <p>You have successfully logged in.</p>
        </DialogContent>
        <DialogActions>
          <Button className='btn btn-success' onClick={() => setOpen(false)}>Close</Button>
        </DialogActions>
      </Dialog>
</div>
  )
}

export default Navbar