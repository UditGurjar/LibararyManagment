import { CardElement, ElementsConsumer } from '@stripe/react-stripe-js';
import axios from 'axios';
import React from 'react'


function CardComponent(props) {
    const jwt =  JSON.parse(localStorage.getItem("currentUser"));

   const handleSubmit=async(event)=>{
    debugger
    event.preventDefault();
const {stripe,elements,data}= props

if(!stripe||!elements) return;
const card=elements.getElement(CardElement);
const { error, paymentMethod } = await stripe.createPaymentMethod({
    type: 'card',
    card: card,
});

if (error) {
    console.error(error);
} else {
    // Send paymentMethod.id to your server to complete the payment
  

const PaymentData={
paymentMethodId:paymentMethod.id,
  amount:props.data.fineonBook,
  bookIssueId:data.bookIssueId
}
console.log(PaymentData)

const headers= {Authorization:`Bearer ${jwt.token}`}

axios.post("https://localhost:7192/api/BookIssue/complete",PaymentData,{ headers: headers}).then((res)=>{
    console.log(res);
})
    // TODO: Send the paymentMethod.id to your server to complete the payment
    // After successful payment, update the fine status in your database
}

   }

   const CARD_ELEMENT_OPTIONS={
    style:{
      base:{
          color:"green",
          fontSize:"25px",
          fontfamily:"sans-serif",
          fontSmoothing:"antialiased",
          "::placeholder":{
color:"grey",
          }

      },
      invalid:{
          color:"red",
          ":focus":{
              color:"red",
          }
      }
    }
  }

  return (
    <div>
        <form onSubmit={(event)=>handleSubmit(event)}>
       
        <div className='cardTitle'>Fill the Card Details  </div>
        <CardElement options={CARD_ELEMENT_OPTIONS}/>
    <button disabled={!props.stripe} className='btn-pay'>${props.data.fineonBook}</button>
        </form>
    </div>
  )
}

export default function InjectCheckout(props){
    
    return <ElementsConsumer>
        {
            ({stripe,elements})=>(
                <CardComponent stripe={stripe} elements={elements} data={props.fine} />
            )
        }
    </ElementsConsumer>
}