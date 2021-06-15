import './App.css';
import {BrowserRouter as Router} from 'react-router-dom';
import Routes from './routes';
import Header from './components/Header/header';

function App() {
  return (
    <Router>
      <div className="ContainerMain">
        <Header/>
        <Routes/>
      </div>
    </Router>
  );
}

export default App;
