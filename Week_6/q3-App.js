import './App.css';
import CalculateScore from './Components/CalculateScore';
import './Stylesheets/mystyle.css';

function App() {
  return (
    <div className="App">
      <CalculateScore name="Rick" school="St. Anns" total={459} goal="Become a Full-Stack Developer"/>
    </div>
  );
}
export default App;