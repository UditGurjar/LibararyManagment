import { Box, Button, Card, CardActions, CardContent, Rating, TextareaAutosize, Typography } from '@mui/material'
import axios from 'axios'
import React from 'react'
import { useState } from 'react'
import { useEffect } from 'react'



function Ratings(props) {
   
const[store,setstore]=useState([])
const [ratingValue, setRatingValue] =useState(0);
const[reviewValue,setreviewValue]=useState();


const jwt =  JSON.parse(localStorage.getItem("currentUser"));
  const headers= {Authorization:`Bearer ${jwt.token}`}

useEffect(() => {
  debugger
    if (props) {
      setstore(props.senddata);
    }
   getAll()
   getAllReview()

  }, [props.senddata]);

const textChANGE=(event)=>{
  debugger
  setreviewValue({...reviewValue,[event.target.name]:event.target.value})
}

const handleRatingChange = (event,newValue, item) => {
  debugger
  console.log(item)
 var bookRatingType=newValue;

 var bookId=item.book.bookId;
var userId=item.user.userId
var bookNetRating=0
const data={
  bookRatingType,
  bookId,
  userId,
  bookNetRating
}


axios.post("https://localhost:7192/api/Rating",data,{ headers: headers}).then((res)=>{
  getAll()
  console.log(res)
})
console.log(data)

}

function getAllReview()
{
  debugger
  if (props)
  {
    axios.get("https://localhost:7192/api/Rating/reviewBook/"+props.senddata[0].user.userId,{ headers:headers }).then((res)=>{
      setreviewValue(res.data)
    })
  }
 
}



function reviewSubmit(item){
 
var bookId=item.book.bookId;
var userId=item.user.userId
var bookReviewText=reviewValue.bookReviewText;
const data={
  bookId,
  userId,
bookReviewText
}


axios.post("https://localhost:7192/api/Rating/Review",data,{ headers: headers }).then(()=>{
  
  getAllReview();
})
}

function getAll()
{
  debugger
  if (props)

  {
    axios.get("https://localhost:7192/api/Rating/"+props.senddata[0].user.userId,{ headers: headers}).then((res)=>{
      setRatingValue(res.data)
    })
  }
 
}


  return (
    <div>
        <h1 className='text-center text-primary'>My Books</h1>
    
    <Box
        sx={{
          display: 'flex',
          flexWrap: 'wrap',
          gap: '16px',
        }}
      >
        {store.map((item) => (
          <Card key={item.book.id} sx={{ width: '250px' ,borderStyle:"outset"}}>
            <CardContent>
            <Typography variant="body2" textAlign="center" color="brown" fontSize={20} fontFamily="fantasy">{item.book.bookTitle}</Typography>
            <u>
            <i style={{color:'black',fontsize:'5px'}}><b> By:</b></i>&nbsp;
      
            <b style={{ color: "grey",fontSize:'20px',fontFamily:"sans-serif" }}>@{item.book.bookAuthor}</b>
        </u> 

           

            </CardContent>
     <div className='row form-group'>
        <div className='col-11'>
        <TextareaAutosize
         name="bookReviewText"
  minRows={2}
  maxRows={3}
  //multiline
  placeholder="YOUR FEEDBACK "
  value={reviewValue && reviewValue.length > 0 ? reviewValue.find((r) => r.bookId === item.book.bookId)?.bookReviewText || null : null}
  onChange={(event)=>textChANGE(event)}
  style={{ width: "100%",fontFamily:"-moz-initial",fontSize:"20px",color:"blueviolet" }}
/>
        </div>
   <div className='offset-6'>
   <button className='btn btn-warning' onClick={()=>reviewSubmit(item)}>Submit</button>
   </div>

     </div>
    
    <div style={{ display: 'block', padding: 30 }}>
   
      <Box component="fieldset" mb={3} borderColor="transparent">
        <Typography component="legend">
            Please Rate our Book
        </Typography>
        <Rating
        name="my-rating"
        value={ratingValue && ratingValue.length > 0 ? ratingValue.find((r) => r.bookId === item.book.bookId)?.bookRatingType || null : null}
        onChange={(event,newValue) => handleRatingChange(event,newValue, item)}
      />
      </Box>
    </div>



          </Card>
        ))}

      </Box>
   
    </div>
  )
}

export default Ratings