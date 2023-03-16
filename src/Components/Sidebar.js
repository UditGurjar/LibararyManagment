import axios from 'axios';
import React, { useEffect, useState } from 'react'

function Sidebar() {

  const [people, setPeople] = useState([]);
  const [index, setIndex] = useState(0);


  useEffect(() => {
  
    getAll();

    const lastIndex = people.length - 1;
    if (index < 0) {
      setIndex(lastIndex);
    }
    if (index > lastIndex) {
      setIndex(0);
    }
    
  },[index, people]);


  useEffect(() => {
  
    let slider = setInterval(() => {
      setIndex(index + 1);
    }, 2000);
    return () => clearInterval(slider);
  }, [index]);

  function getAll(){
    axios.get("https://localhost:7192/api/AllBooks/topratedbooks").then((res)=>{
      setPeople(res.data)
    })
  }
  return (
    <div>
      <div className="side" >
        <div className="card">
          <div className="card-body">
            <h3 className="text-danger text-center fw-bold ">Instructions</h3>
            <p className="p" style={{fontSize:"20px",fontFamily:"serif"}}>
            Our library has a generous borrowing policy that allows
             borrowers to check out as many items as they like for 
             a period of 6 weeks. Borrowers may renew items up to
              3 times, as long as there are no holds on the item. 
              Borrowers are responsible for returning items on time
               and in good condition.
             Overdue fines may be assessed for items that are 
             returned late. If an item is lost or damaged, the borrower
              will be responsible for the replacement cost of the item. 
            </p>
            
          </div>
        </div>
        <section className="section">
      <div className="title">
        <h2>
         Our Best Books
        </h2>
      </div>
      <div className="section-center">
      
        {people?.map((person, personIndex) => {
          let position = "nextSlide";
          if (personIndex === index) {
            position = "activeSlide";
          }
          if (
            personIndex === index - 1 ||
            (index === 0 && personIndex === people.length - 1)
          ) {
            position = "lastSlide";
          }
          return (
            <article key={person.bookId} className={position}>
              <img src={person.bookImage}  className="person-img" />
              <h4>{person.bookAuthor}</h4>
              <p className="title">{person.bookTitle}</p>
              <p className="text">{person.bookDescription}</p>
            
            </article>
          );
        })}
       
      </div>
    </section>
      </div>
    </div>
  );
}

export default Sidebar;
