import {  ArrowBack,  LibraryAddCheck   } from '@mui/icons-material';
import { Avatar, Card,  CardContent,
   CardHeader,  Dialog,  DialogContent,  DialogTitle,  IconButton, Tooltip, Typography } from '@mui/material';
import { brown} from '@mui/material/colors';
import { height, width } from '@mui/system';
import { Elements } from '@stripe/react-stripe-js';
import { loadStripe } from '@stripe/stripe-js';
import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useLocation, useNavigate } from 'react-router-dom';
import swal from 'sweetalert';
import InjectCheckout from './CardComponent';
import Ratings from './Ratings';


const stripePromise=loadStripe("pk_test_51LiGwdCV6VjZandPzE7CxykmPYzU7hjB5CBMRjBzeZuCu6WE6pQLHanT87UnukVR9W4kkOQF5TsAhawCUi4s20LZ00PlTnzHEW");


export default function Profile() {
  const statusMap={
    1:'Pending',
    2:'Approved',
    3:'DisApproved'
  }
  const jwt =  JSON.parse(localStorage.getItem("currentUser"));

const[getData,setgetData]=useState([]);
const[userData,setuserData]=useState([]);
const[fineData,setfineData]=useState([]);
const [showPopup, setShowPopup] = useState(false);
const [sendprops,setsendProps]=useState()

const navigate=useNavigate()
const location=useLocation();


useEffect(()=>{
 

  getAllbyId();
  getAll();
  getAllFineUsers();
},[])

function getAllbyId(){

  const headers= {Authorization:`Bearer ${jwt.token}`}

  axios.get("https://localhost:7192/api/BookIssue/"+location.state,{ headers: headers}).then((d)=>{
    debugger
    setgetData(d.data);

}).catch((e)=>{
  alert(e);
})
}

function getAll(){                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
const headers= {Authorization:`Bearer ${jwt.token}`}

  axios.get("https://localhost:7192/api/BookIssue",{ headers: headers}).then((d)=>{
    setuserData(d.data);

}).catch((e)=>{
  alert(e);
})
}

function getAllFineUsers(){
  const headers= {Authorization:`Bearer ${jwt.token}`}
  
  axios.get("https://localhost:7192/api/Rating/GetFineUser/"+location.state,{ headers: headers}).then((d)=>{
    setfineData(d.data);

}).catch((e)=>{
  alert(e);
})
}


function approvedBook(id){
const headers= {Authorization:`Bearer ${jwt.token}`}

axios.put("https://localhost:7192/api/AllBooks/approveBook/"+id,{ headers: headers },).then((res)=>{
getAll();
}).catch((e)=>{
  swal({
    title: "Books are not  available. 😀 ",
    icon: "error",
  }) 
})
}

function declineBook(id){
const headers= {Authorization:`Bearer ${jwt.token}`}

  axios.put("https://localhost:7192/api/AllBooks/Declinebook/"+id,{ headers: headers }).then((res)=>{
  getAll();
  }).catch((e)=>{
    alert(e);
  })
  }


function homePage(){
  debugger
  navigate("/adddata")
}

const FineBooks=(t)=>{
  setsendProps(t)
 setShowPopup(true);

}
const handlePopupClose = () => {
  setShowPopup(false);
}



  return (
    <div>
        {getData.length > 0 && (
       <Card  sx={{ maxWidth:1200,maxHeight:1000,borderStyle:"solid",padding:5,margin:5,bgcolor: "#E8F5E9"  }}>
        <CardHeader
        avatar={
          <Avatar sx={{ bgcolor: "black" }} src= {getData[0].user.image}>
        
          </Avatar>
        }
        action={
          <Tooltip title="Back to page">
            <IconButton onClick={homePage} title="page"> 
              <ArrowBack />
            </IconButton>
          </Tooltip>
        }

        titleTypographyProps={{variant:'h1',fontSize:25 }}
        title={ 
          getData[0].user.userName
        }
        subheader="September 14, 2016"
      />
      <CardContent>
  
  <Typography variant="body2" color="green" fontSize={20} fontFamily="fantasy">
  
     <Ratings senddata= {getData
          .filter(item => item.bookStatus === 2)
          .map(item => item)
        }/>
  </Typography>
  <br/>
  <Typography variant="body2" color="red" fontSize={20} fontFamily="cursive">
   
   {getData
     .filter(item => item.bookStatus === 1).length>0?(
       <>
         Pending Books:
        {getData.filter(item=>item.bookStatus===1).map(item => item.book.bookTitle)
     .join(", ")}
       </>
     ):(<h1>You have No Pending books </h1>)
        }
 </Typography>

<Typography variant="body2" color="blue" fontWeight="bold"  fontSize={22} fontFamily="sans-serif">
{fineData.length>0?(<p className='text-success'>Fine on Books:{fineData.map((t, index) => (
  <button className='btn-fine' key={index} onClick={() => FineBooks(t)}>
    {t.book.bookTitle}
  </button>
))}</p>):(<div/>)}


</Typography>


</CardContent>
    </Card>
        
        )}

{
  location.state==1?(
<><h1 className='col-9 m-2 text-center'>Users List</h1><br/>
          <div className='col-9 p-2 m-2'>
            
<table className='table table-striped table-bordered table-active table-hover table-condensed'  >
<thead className='table-primary'>
   <tr>
    <th>User Name</th>
    <th>Book Name</th>
    <th>Book Status</th>
    <th>Button</th>
   </tr>
   </thead>

   <tbody>
   {userData?.map((item)=>{
  return <tr className='text-success font-weight-bold'>
    <td >{item.user.userName}</td>
    <td>{item.book.bookTitle}</td>
    <td><span class="badge badge-success rounded-pill d-inline">{statusMap[item.bookStatus]}</span></td>
          {item.bookStatus==1 || item.bookStatus==3?(<td>
    <button className='btn btn-info m-1' data-toggle='modal' data-target="#editModal" onClick={()=>approvedBook(item.bookIssueId)}>Approved  <i class="fa fa-thumbs-up"></i></button>
      <button  className='btn btn-danger'  onClick={()=>declineBook(item.bookIssueId)}>Decline <i class="fa fa-thumbs-down" aria-hidden="true"></i></button> 
      </td>):(<> 
        <IconButton sx={{ color: brown[500] }} >
         <LibraryAddCheck />
    </IconButton>
      </>
    
      // <span class="badge bg-primary text-wrap p-3 m-3"><i class="fa fa-check fa-xl fa-solid"></i></span>
      )
   }

  </tr>
  })}

   </tbody>
</table>
</div>
</>

  ):(<div/>)
}

<Dialog open={showPopup} onClose={handlePopupClose} minWidth="60%" fullWidth >
        <DialogTitle>Pay Your Fine </DialogTitle>
        <DialogContent>
          
          <Elements stripe={stripePromise}>
            <InjectCheckout fine={sendprops} />
          </Elements>
        
        
        </DialogContent>
      </Dialog>

    </div>
  )
}
