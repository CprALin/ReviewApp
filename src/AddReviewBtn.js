import { MdPlaylistAdd } from "react-icons/md";
import { useState } from "react";
import AddReview from "./AddReview";

const AddReviewBtn = () => 
{
    const[isAddRevOpen , setIsAddRevOpen] = useState(false);
    
    const handleAddClick = () =>
    {
        setIsAddRevOpen(true);
    }

    const handleCloseAdd = () =>
    {
        setIsAddRevOpen(false);
    }

    return(
       <div className="Review-Btn">
           <button onClick={handleAddClick}><MdPlaylistAdd className="btn-logo"/></button>

           {isAddRevOpen && <AddReview onClose={handleCloseAdd}/>}
       </div>
    );
}

export default AddReviewBtn;