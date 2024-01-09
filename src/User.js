import { IoCloseOutline } from "react-icons/io5";
import { TbFileDescription } from "react-icons/tb";
import image from "./images/anonymous.png";
import { Link } from "react-router-dom";


const User = ({onClose}) => 
{
    return(
        <div className="Profile">
            <div className="wrapper">
                <span className="icon-close" onClick={onClose}>
                    <IoCloseOutline/>
                </span>

                <div className="form-box login">
                <h2>Profile</h2>
                <form name="Profile">
                    <div className="photo-box">
                    <img src={image} alt="user" />   
                    <input
                        type="file"
                    />
                    </div>s
                    <div className="input-box">
                        <span className="icon">
                            <TbFileDescription/>
                        </span>
                    <input
                        type="text"
                    />
                    <label>Description</label>
                    </div>
                    <div className="login-register">
                        <p>
                            <Link className="update-link" >Update</Link>
                        </p>
                    </div>    
                    <button type="submit" className="btn-sub">
                      LogOut
                    </button>
                </form>
                </div>
            </div>
        </div>    
    );
}

export default User;