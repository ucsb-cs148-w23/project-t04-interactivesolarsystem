import logo from './logo.svg';
import './App.css';

function myFunction() {

  window.alert("What")

}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Hello World! <br></br>
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React (or something.)
        </a>
      </header>
    </div>
  );
}

export default App;
