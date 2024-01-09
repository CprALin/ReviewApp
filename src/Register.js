import { IoPersonSharp } from "react-icons/io5";
import { IoCloseOutline } from "react-icons/io5";
import { IoIosMail } from "react-icons/io";
import { FaLock } from "react-icons/fa";
import { Link } from "react-router-dom";
/* import { useState } from "react";
import axios from "axios"; */

const Register = ({onClose , onLoginClik}) => 
{
 /*   const[userName, setUserName] = useState('');
   const[userEmail, setUserEmail] = useState('');
   const[userPassword, setUserPassword] = useState('');

   const handleNameChange = (value) =>
   {
      setUserName(value);
   }

   const handleEmailChange = (value) => 
   {
      setUserEmail(value);
   }

   const handlePasswordChange = (value) =>
   {
      setUserPassword(value);
   } */
   
   const handleSave = () =>
   {
       /* const data = {
          UserName : userName,
          userEmail : userEmail,
          userPassword : userPassword
      };
      const url ='http:/localhost:32771/api/Register';
      axios.post(url,data).then((result) => {
          toast(result.data);
      }).catch((error) => {toast(error);})  */ 
   }
   
   return(
     <div className="Profile">
        <div className="wrapper">
            <span className="icon-close" onClick={onClose}>
                <IoCloseOutline/>
            </span>
            <div className="form-box register">
                <h2>Registration</h2>
                <form name="Register">
                    <div className="input-box">
                        <span className="icon"><IoPersonSharp /></span>
                        <input type="text" id="userName" required /* onChange={(e) => {handleNameChange(e.target.value)}} *//> 
                        <label>Username</label>
                    </div>
                    <div className="input-box">
                        <span className="icon"><IoIosMail /></span>
                        <input type="email" id="userEmail" required /* onChange={(e) => {handleEmailChange(e.target.value)}}  *//>
                        <label>Email</label>
                    </div>
                    <div className="input-box">
                    <span className="icon"><FaLock /></span>
                    <input type="password" id="userPassword" required /* onChange={(e) =>{handlePasswordChange(e.target.value)}} *//>
                    <label>Password</label>
                </div>
                <div className="remember-forgot">
                    <label><input type="checkbox" />I agree to the terms & conditions.</label>
                </div>
                <button type="submit" className="btn-sub" onClick={handleSave()}>Register</button>
                <div className="login-register">
                    <p>Already have an account? <Link className="login-link" onClick={onLoginClik}>Login</Link></p>
                </div>
                </form>
            </div>
        </div> 
    </div>    
   );
}

export default Register;