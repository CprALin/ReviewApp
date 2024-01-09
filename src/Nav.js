import { Link , useLocation } from "react-router-dom";
import Logo from "./Logo";
import { IoHome } from "react-icons/io5";
import { MdContentPasteSearch } from "react-icons/md";
import { GrInfo } from "react-icons/gr";
import { CgProfile } from "react-icons/cg";
import Login from "./Login";
import Register from "./Register";
import { useState } from "react";
import User from "./User";

const Nav = () => 
{
   const [isLoginOpen , setLoginOpen] = useState(false);
   const [isRegisterOpen , setRegisterOpen] = useState(false);
   const [isUserLogin , setUserLogin] = useState(false);

   var location = useLocation();

   const handleIsLogin = () =>
   {
      setUserLogin(true);
      setLoginOpen(false);
      setRegisterOpen(false);
   }

   const handleLoginClick = () => 
   {
      setLoginOpen(true);
   }

   const handleLoginRegisterClick = () =>
   {
      setRegisterOpen(true);
      setLoginOpen(false);
   }

   const handleRegisterLoginClick = () => 
   {
      setRegisterOpen(false);
      setLoginOpen(true);
   }

   const handleCloseLogin = () => 
   {
      setLoginOpen(false);
      setRegisterOpen(false);
      setUserLogin(false);
   }

   return(
    <header>
       <Logo />
       <nav className="Nav-Bar">
           <ul>
              <li className={location.pathname === '/' ? 'active' : ''}><Link to="/"><IoHome/></Link></li>
              <li className={location.pathname === '/Content' ? 'active' : ''}><Link to="/Content"><MdContentPasteSearch/></Link></li>
              <li className={location.pathname === '/About' ? 'active' : ''}><Link to="/About"><GrInfo/></Link></li>
              <li>
                 <Link><CgProfile onClick={handleLoginClick}/></Link>
              </li>
           </ul>
       </nav>

       {isUserLogin && <User onClose={handleCloseLogin} />}
       {isLoginOpen && <Login onClose={handleCloseLogin} onRegisterClick={handleLoginRegisterClick} onLogin={handleIsLogin}/>}
       {isRegisterOpen && <Register onClose={handleCloseLogin} onLoginClik={handleRegisterLoginClick}/>}

    </header>   
   );  
}

export default Nav;

