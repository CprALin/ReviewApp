import { MdAddBusiness } from "react-icons/md";
import AddContent from "./AddContent";
import { useState } from "react";

const AddRestaurantBtn = () => {

    const[isAddBtnOpen , setIsAddOpen] = useState(false);

    const handleAddClick = () => 
    {
        setIsAddOpen(true);
    }

    const handleCloseAdd = () => 
    {
        setIsAddOpen(false);
    } 

   return(
      <>
         <div className="Add-Btn">
                <button onClick={handleAddClick}><MdAddBusiness className="btn-logo"/></button> 
         </div>

         {isAddBtnOpen && <AddContent onClose={handleCloseAdd}/>}
      </>
   );     
} 

export default AddRestaurantBtn;