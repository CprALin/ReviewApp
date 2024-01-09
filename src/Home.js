import React from 'react';
import { FaRegStar, FaStar } from "react-icons/fa";

const Home = () => {
  const stars = [<FaRegStar/>,<FaRegStar/> , <FaStar/> , 'Wellcome' , <FaStar/> , <FaRegStar/>,<FaRegStar/>];

  return (
    <div className="home-content">
      <div className="concept-stars">
        {stars.map((val, index) => (
          <div key={index} className="star">
            <div className="hover">
              <div></div>
              <div></div>
              <h1>{val}</h1>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Home;
