import ReviewsList from "./ReviewsList";
import AddReviewBtn from "./AddReviewBtn";
import image from "./images/restaurant-background.png";


const Reviews = () =>
{
    return(
       <div className="Reviews">
          <div className="Reviews-Component">
             <div className="reviewImg">
                 <img src={image} alt="restaurant"/>
             </div>
             <div className="reviewDescription">
                  <h2>Description : </h2>
                  <p>La Gusto del Sole, ne propunem să vă oferim o experiență culinară de neuitat într-un ambient 
                     primitoare și plin de farmec. Situat în inima orașului, restaurantul nostru aduce un strop de soare în fiecare farfurie, 
                     oferindu-vă o selecție rafinată de preparate inspirate din bucătăria internațională și locală.</p>
             </div>
             <h1>Reviews</h1>
             
             <ReviewsList />

             <AddReviewBtn />

          </div>
       </div>
    );
}

export default Reviews;