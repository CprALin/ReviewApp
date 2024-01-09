import Nav from './Nav';
import Home from './Home';
import Content from './Content';
import About from './About';
import Missing from './Missing';
import Reviews from './Reviews';
import Footer from './Footer';
import {Routes , Route} from 'react-router-dom';

function App() {
  return (
    <div className="App">
         <Nav />
         <Routes>
            <Route path='/' element={<Home />}/>
            <Route path='/Content' element={<Content />}/>
            <Route path='/About' element={<About />}/>
            <Route path='/Reviews' element={<Reviews />}/>
            <Route path='*' element={<Missing />}/>
         </Routes>
         <Footer />
    </div>
  );
}

export default App;
