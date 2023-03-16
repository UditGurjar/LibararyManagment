import axios from "axios";
import React, { useEffect, useState } from "react";
import { Alert, Box, Rating, Snackbar, Typography } from '@mui/material'
import swal from "sweetalert";







function Content() {
  const [allData, setallData] = useState();
  const [showSuccess, setShowSuccess] = useState(false)
  const [checkUser, setCheckUser] = useState()
   const[reviewData,setreviewData]=useState()
   const [showReview, setShowReview] = useState(false);

  const handleClose = () => {
    setShowSuccess(false);
  };

  const jwt =  JSON.parse(localStorage.getItem("currentUser"));
  

  useEffect(() => {
    const jwt = localStorage.getItem("currentUser");
    if(jwt){
      const [header, payload, signature] = jwt.split('.');
      const decodedPayload = JSON.parse(atob(payload));
      const userId = decodedPayload.nameid;
    setCheckUser(userId)
    }

    getAll();
    console.log(allData);
  }, []);

  function getAll() {
  //   const jwt =  JSON.parse(localStorage.getItem("currentUser"));
  //  const headers= {Authorization:`Bearer ${jwt.token}`}
    axios
      .get("https://localhost:7192/api/AllBooks")
      .then((res) => {
        setallData(res.data);
      })
      .catch((e) => {
        alert(e);
      });

      
  }

  function issuePage(bookid) {
  const userid=checkUser
    const data={
    bookid,
    userid
 }

 const headers= {Authorization:`Bearer ${jwt.token}`}
  axios.post(`https://localhost:7192/api/BookIssue`,data,{ headers:headers })
      .then((res) => {
        if(res){
          setShowSuccess(true)
        }
      })
      .catch((error) => {
        swal({
          title: "You Already Issue This Book 😀 ",
          icon: "error",
        }) 
      })
    
    
  }
function GetAllReview(id)
{
   const headers= {Authorization:`Bearer ${jwt.token}`}

  axios.get("https://localhost:7192/api/Rating/allReview/"+id,{ headers:headers }).then((res)=>{
    setreviewData(res.data)
    setShowReview(true)
    console.log(res.data);
  }).catch((e)=>{
  setShowReview(false)
  })
}



  return (
    <div>
      <div className="main">
        <div className="container-fluid div1">
          <div className="row text-center div2">
            {allData?.map((item) => {
              return (
                <div
                  className="col-10 col-md-4 mt-5 div3"
                >
                  <div
                    class="card p-2 div4"
                  >
                      <img src={item.bookImage} className="img"/>
                      <div class="pl-1">
                        <p className="p">
                          <b style={{fontSize:"20px",color:"maroon"}}>{item.bookTitle}</b>
                        </p>
                        <p className="p">
                        <u>
                        <i style={{color:'black',fontsize:'20px'}}><b> By:</b></i>&nbsp;
                         <i><b style={{ color: "#cf3737",fontSize:'20px' }}>@{item.bookAuthor}</b></i> 
                          </u> 
                     
                        </p>
                        <p className="p">
                          <b>
                          <i style={{color:'black',fontsize:'20px'}}> Decription:
                          </i>
                          <b style={{ color: "grey",fontSize:'15px'}}>
                            {item.bookDescription}
                          </b>
                          </b>
                        </p>
                        <p style={{ color: "red"}}>
                         <b>{
                          item.totalBooks===0?(<>
                           Available after: {new Date(item.bookExpiryDate).toLocaleDateString('en-GB')}
                          </>):(
                            <>
                                 Total Books:   {item.totalBooks}
                            </>
                          )
                          }</b>
                        </p>
                      </div>
                      <Box
   
    >
      
<Typography variant="body1" fontSize={20} fontFamily="fantasy">{item.bookNetRating}  &nbsp;
<Rating value={item.bookNetRating} readOnly precision={0.5}  />
{/* <Review  data={item.bookId}/> */}
<button className='btn btn-info' data-toggle="modal" data-target="#newModal" onClick={()=>GetAllReview(item.bookId)}>
         ALl Reviews</button>

</Typography>
    </Box>
                  </div>
                  <div className="btn">
                    
                    <button
                    disabled={item.totalBooks === 0 || checkUser==null}
                      onClick={() => issuePage(item.bookId)}
                    >
                      Issue Book
                    </button>
                  
                  </div>
                </div>
              );
            })}
          </div>
        </div>
      </div>

<div>
{showSuccess?<Snackbar
     open={showSuccess}
     autoHideDuration={6000}
     onClose={handleClose}
     
     >
     <Alert onClose={handleClose} severity="success" sx={{ width: '100%' }}>
     Your Request went to Admin for Approved
        </Alert>
     </Snackbar>:null}
</div>


<form>
  {
    showReview?( 
    <div className='modal'  id='newModal' role="dialog">
    <div className='modal-dialog'>
      <div className='modal-content'>
      <div className='modal-header'>
              <div className='modal-title text-dark fw-bold'>All Reviews</div>
              <button className='close' data-dismiss="modal" ><span>&times;</span></button>
            </div>
        {
          reviewData?.map((item=>{
            return(
              <>
                  
            <div className='modal-body'>
              <div className='form-group row'>
                <label className='col-sm-5 badge  text-wrap text-uppercase fw-bold' for='txtname'>{item.user.userName}</label>
                <div className='col-sm-7'>
                  
            <u>
              <i>
              <div class="badge bg-warning text-wrap text-uppercase fw-bold">
              <span>{item.bookReviewText} </span>
</div>
             
              </i>
          
              </u>
                </div>
              </div>
             
            
    
            </div>
              </>
            
            )
          }))
        }
   
      
      </div>
    </div>
  </div>):(
    <div className='modal' id='newModal' role="dialog">
       <div className='modal-dialog'>
       <div className='modal-content'>
       <div className='modal-header'>
              <div className='modal-title text-primary'>All Reviews</div>
              <button className='close' data-dismiss="modal" ><span>&times;</span></button>
            </div>
            <div className='modal-body'>
              <h1 className="text-danger text-center">This book has no reviews</h1>
            </div>
       </div>
       </div>
    
    </div>
  )
  }
 

</form> 

    </div>
  );
}

export default Content;
