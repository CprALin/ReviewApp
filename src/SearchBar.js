import SearchLogo from './SearchLogo';

const SearchBar = () =>
{
    return(
      <div className="Search-Bar"> 
        <form className="SearchBar">  
            <input id="search" type="text" placeholder="Search..."  className="search-box" />
            <SearchLogo />
        </form>
      </div>    
    );
}

export default SearchBar;