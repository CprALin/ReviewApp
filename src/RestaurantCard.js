import { Link } from "react-router-dom";
import image from "./images/restaurant-background.png";
import { LiaStarSolid } from "react-icons/lia";

const RestaurantCard = () =>
{   
    var post = 'La Gusto del Sole, ne propunem să vă oferim o experiență culinară de neuitat într-un ambient primitoare și plin de farmec. Situat în inima orașului, restaurantul nostru aduce un strop de soare în fiecare farfurie, oferindu-vă o selecție rafinată de preparate inspirate din bucătăria internațională și locală.';
    return(
        <div className="Card-Content">
               <div className="Image-Container">
                  <img src={image} alt="restaurant" />
               </div>
               <div className="Title-Container">
                  <h2>Gusto del Sol</h2>
               </div>
               <div className="Stars-Container">
                  <p><LiaStarSolid /><LiaStarSolid /><LiaStarSolid /><LiaStarSolid /><LiaStarSolid /></p>
               </div>
               <div className="Description-Container">
                  <p>{post.length <= 25 ? post : `${post.slice(0, 25)}...`}</p>
               </div>
               <div className="Link">
                  <Link to="/Reviews">View</Link>
               </div> 
        </div>
    );
}

export default RestaurantCard;