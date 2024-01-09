import SearchBar from "./SearchBar";
import AddRestaurantBtn from "./AddRestaurnatBtn";
import RestaurantCard from "./RestaurantCard";

const Content = () => {
    return(
        <div className="Content">
            <SearchBar />
            <RestaurantCard />
            <AddRestaurantBtn />
        </div>
    );
}

export default Content;