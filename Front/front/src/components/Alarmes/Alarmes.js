import React,{useState,useEffect} from 'react';
import './Alarmes.css';
import apiAlarm from '../../services/cadastroAlarme';
import apiEquipName from '../../services/pegueNomeEquip';
export default function Alarmes()
{
  const[alarm,setAlarm] = useState({
    descricao:"",
    classificacao:"",
    equipRelacionado:0,
    status:true
  })

  const[nomesEquip, setNomesEquip] = useState([])

  useEffect(()=>{

      async function fetchData(){

          const listaNomes = await apiEquipName();
    
          setNomesEquip(listaNomes);
      }

      fetchData()

      
  },[])

  function handleInputChange(event){

    const {name,value} = event.target;
    
    setAlarm({...alarm,[name]:value});


}
  function handleSelectedValues(event){
    let {name,value} = event.target;

    value = name === "equipRelacionado" ? parseInt(value) : value;
  
    setAlarm({...alarm,[name]:value});
  } 

async function handleSubmit(event){

  event.preventDefault();

  const {descricao, classificacao,equipRelacionado,status} = alarm;

  let data = new Date();

  data = data.getDate() + '/' + (data.getMonth()+1) + '/'+ data.getFullYear();

  const dados = {
    descricao,
    classificacao,
    equipRelacionado,
    data,
    status
  }

  await apiAlarm(dados);


}

    return(

          <form className="ContainerEquip" onSubmit={handleSubmit}>
            <h1>Tela de Cadastro de Alarmes</h1>
            <div className="inputContainer">
              <label>Descrição do Alarme: </label>
              <input placeholder="Descrição" name="descricao" onChange={handleInputChange}/>
              <label>Classificação: </label>
              <select placeholder="Classificação" name="classificacao" onChange={handleSelectedValues}>
                <option value="0">Selecione a Classificação</option>
                <option value="Alto">Alto</option>
                <option value="Médio">Médio</option>
                <option value="Baixo">Baixo</option>
              </select>
              <label>Equipamento: </label>
              <select  onChange={handleSelectedValues} name="equipRelacionado">
                <option value="0">Selecione um equipamento</option>
                {nomesEquip.map((item,index)=>{
                  return(
                    <option key={index}value={item.id}>{item.Nome}</option>
                  )
                })}
              </select>
            </div>
            <button type="submit" className="BotaoEquip">
                Cadastrar Alarme
            </button>
          </form>          
        )
}