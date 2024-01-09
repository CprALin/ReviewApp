import { IoCloseOutline } from "react-icons/io5";
import { MdOutlineDriveFileRenameOutline } from "react-icons/md";
import { TbFileDescription } from "react-icons/tb";

const AddReview = ({onClose}) => 
{
    return(
        <div className="Profile">
        <div className="wrapper">
            <span className="icon-close" onClick={onClose}>
                <IoCloseOutline/>
            </span>
            <div className="form-box register">
                <h2>New Review</h2>
                <form name="Review">
                    <div className="input-box">
                        <span className="icon"><MdOutlineDriveFileRenameOutline /></span>
                        <input type="text" id="reviewTitle" required /> 
                        <label>Title</label>
                    </div>
                    <div className="input-box">
                        <input type="number" id="reviewRating" required />
                        <label>Rating</label>
                    </div>
                    <div className="input-box">
                    <span className="icon"><TbFileDescription /></span>
                    <input type="text" id="reviewDescription" required />
                    <label>Description</label>
                </div>
                <button type="submit" className="btn-sub">Add</button>
                </form>
            </div>
        </div> 
      </div>  
    );
}

export default AddReview;