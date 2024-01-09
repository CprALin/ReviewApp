import { IoCloseOutline } from "react-icons/io5";
import { MdOutlineDriveFileRenameOutline } from "react-icons/md";
import { FaLocationDot } from "react-icons/fa6";
import { TbFileDescription } from "react-icons/tb";
import { IoMdImages } from "react-icons/io";



const AddContent =  ({onClose}) => 
{
   return(
      <div className="Profile">
        <div className="wrapper">
            <span className="icon-close" onClick={onClose}>
                <IoCloseOutline/>
            </span>
            <div className="form-box register">
                <h2>New Restaurant</h2>
                <form name="Register">
                    <div className="input-file-box">
                        <span className="icon"><IoMdImages /></span>
                        <input type="file" id="restaurantImage" required className="File-Input"/>
                        <label>+ Image</label>
                    </div>
                    <div className="input-box">
                        <span className="icon"><MdOutlineDriveFileRenameOutline /></span>
                        <input type="text" id="restaurantName" required /> 
                        <label>Name</label>
                    </div>
                    <div className="input-box">
                        <span className="icon"><FaLocationDot /></span>
                        <input type="text" id="restaurantAdress" required />
                        <label>Adress</label>
                    </div>
                    <div className="input-box">
                    <span className="icon"><TbFileDescription /></span>
                    <input type="text" id="restaurantDescription" required />
                    <label>Description</label>
                </div>
                <button type="submit" className="btn-sub">Add</button>
                </form>
            </div>
        </div> 
      </div>  
   );
}

export default AddContent;