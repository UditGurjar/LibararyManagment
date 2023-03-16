import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Profile from "./Components/Profile";
import AddData from "./Components/AddData";




function App() {
  return (


<BrowserRouter>

   <Routes>
    <Route path="/" element={<AddData/>}/>
    <Route path="/adddata" element={<AddData/>}/>
    <Route path="/profile" element={<Profile/>}/>
   </Routes>

   </BrowserRouter>

  );
}

export default App;
