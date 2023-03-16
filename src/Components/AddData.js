import { GoogleOAuthProvider } from '@react-oauth/google'
import React from 'react'
import Content from './Content'
import Footer from './Footer'
import Header from './Header'
import Navbar from './Navbar'
import Sidebar from './Sidebar'


function AddData() {
  return (
    <div>
         <Header />
         <GoogleOAuthProvider clientId="206986272307-ansblv81ksjd6p43mmdh17lon8t64bdf.apps.googleusercontent.com">
         <Navbar />
         </GoogleOAuthProvider>
      
          <div className="container1">
            <div className="content">
              <Content />
            </div>
            <div className="sidebar"> 
             <Sidebar />
            </div>
          </div>
           <Footer />
       </div>
  )
}

export default AddData