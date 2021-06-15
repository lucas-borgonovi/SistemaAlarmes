import React,{useState} from 'react';
import './Equipamentos.css';
import apiEquip from '../../services/cadastroEquip';
export default function Equipamentos()
{
    const[equip,setEquip] = useState({
      nome:"",
      numeroSerie:0,
      tipo:""
    })

    function handleInputChange(event){

      const {name,value} = event.target;
      
      setEquip({...equip,[name]:value});
      console.log(equip.nome);

  }
    function handleSelectedValues(event){
      const tipo = event.target.value;

      setEquip(tipo);
    } 

  async function handleSubmit(event){

    event.preventDefault();

    const {nome, tipo} = equip;

    const numeroSerie = parseInt(equip.numeroSerie);


    let data = new Date();

    data = data.getDate() + '/' + (data.getMonth()+1) + '/'+ data.getFullYear();

    const dados = {
      nome,
      numeroSerie,
      tipo,
      data
    }

    console.log(dados)

    await apiEquip(dados);


}



    return(

          <form className="ContainerEquip" onSubmit={handleSubmit}>
            <h1>Tela de Cadastro de Equipamentos</h1>
            <div className="inputContainer">
              <label>Nome do equipamento: </label>
              <input placeholder="Nome do equipamento" name="nome" onChange={handleInputChange}/>
              <label>Número de série: </label>
              <input placeholder="Número de série" name="numeroSerie" onChange={handleSelectedValues}/>
              <label>Tipo: </label>
              <select  name="tipo" onChange={handleInputChange}>
                <option value="0">Selecione o tipo</option>
                <option value="Tensão">Tensão</option>
                <option value="Corrente">Corrente</option>
                <option value="Oleo">Óleo</option>
                </select>
            </div>
            <button type="submit" className="BotaoEquip" >
                Cadastrar Equipamento
            </button>
          </form>          
        )
}