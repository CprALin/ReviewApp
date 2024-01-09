import image from "./images/me.jpg";
import { LiaStarSolid } from "react-icons/lia";


const ReviewsList = () => {
    return(
        <div className="Reviews-List">
            <div className="User-Review">
                <div className="User-Cred">
                    <div className="User-Img">
                        <img src={image} alt="user"/>
                    </div>
                    <div className="User-Name">
                        <p>CprAlin</p>
                    </div>
                </div>    
                <div className="Title-Review">
                    <h3>Nice</h3>
                </div>
                <div className="Rating-Review">
                    <p><LiaStarSolid /><LiaStarSolid /><LiaStarSolid /><LiaStarSolid /><LiaStarSolid /></p>
                </div>
                <div className="Description-Review">
                    <p>O experienta de neuitat</p>
                </div>
                <div className="Date-Review">
                    <p>30/12/2002</p>
                </div>      
            </div>   
        </div>
    );
} 

export default ReviewsList