import {Switch,Route} from "react-router-dom";
import  Equipamentos  from './components/Equipamentos/Equipamentos.js';
import Alarmes from './components/Alarmes/Alarmes.js';
import Visualizacao from './components/Visualizacao/Visualizacao.js';

export default function Routes(props){
    return(

        <Switch>
            <Route exact path="/Equipamentos" component={Equipamentos}/>
            <Route exact path="/Alarmes" component={Alarmes}/>
            <Route exact path="/Visualizacao" component={Visualizacao}/>
        </Switch>
    )
}
