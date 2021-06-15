import './header.css';
import { Link } from 'react-router-dom';

export default function header(){
    return (

        <header>
                <nav className="menu">
                    <Link to="/Equipamentos">Cadastro de Equipamentos</Link>
                    <Link to="/Alarmes">Cadastro de Alarmes</Link>
                    <Link to="/Visualizacao">Visualização</Link>
                </nav>
        </header>
    )
}