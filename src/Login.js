import { IoCloseOutline } from "react-icons/io5";
import { IoIosMail } from "react-icons/io";
import { FaLock } from "react-icons/fa";
import { Link } from "react-router-dom";

const Login = ({onClose , onRegisterClick , onLogin}) =>
{
   return(
    <div className="Profile">
        <div className="wrapper">
            <span className="icon-close" onClick={onClose}>
                <IoCloseOutline/>
            </span>

            <div className="form-box login">
            <h2>Login</h2>
            <form name="Login">
                <div className="input-box">
                <span className="icon">
                    <IoIosMail />
                </span>
                <input
                    type="email"
                    required
                />
                <label>Email</label>
                </div>
                <div className="input-box">
                    <span className="icon">
                        <FaLock />
                    </span>
                <input
                    type="password"
                    required
                />
                <label>Password</label>
                </div>
                <div className="remember-forgot">
                <label>
                    <input type="checkbox" />Remember me  
                </label>
                <Link> Forgot Password?</Link>
                </div>
                <button type="submit" className="btn-sub" onClick={onLogin}>
                   Login
                </button>
                <div className="login-register">
                <p>
                    Don't have an account?{' '}
                    <Link className="register-link" onClick={onRegisterClick}>Register</Link>
                </p>
                </div>
            </form>
            </div>
        </div>
    </div>    
   ); 
}

export default Login;