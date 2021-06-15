import React, {useEffect,useState} from 'react';
import apiAllAlarmes from '../../services/tabelaAlarmes';
import apiUpdateAlarmes from '../../services/updateAlarme';
import handleBool from '../../utils/handleBool';


export default function Visualizacao(){


    const[tabela,setTabela] = useState([]);
    

    useEffect( ()=>{
            
        async function fetchData(){

            await apiAllAlarmes()
                .then((res)=>{
                    insertDataToTable(res);
                })
        }

        fetchData();
 

    },[])

    async function setStatusAlarm(alarme){
        
        alarme.Status === true ? alarme.Status = false : alarme.Status = true;

        await apiUpdateAlarmes(alarme.id,alarme)
        
        await apiAllAlarmes()
            .then((res)=>{
                insertDataToTable(res);
            })
            
        
    }

    async function insertDataToTable(res){

        const tabelaArr = [];

        res.map((item,index)=>{

            let status = handleBool(item.Status)
            
            tabelaArr.push(
                    <tr key={index}>
                            <td>{item.Descricao}</td>
                            <td>{item.Classificacao}</td>
                            <td>{item.Nome}</td>
                            <td>{item.Data}</td>
                            <td>{status}</td>
                            <td>
                                <button onClick={()=>setStatusAlarm(item)}>Desativar</button>
                            </td>
                    </tr>

            )  
        })

        setTabela(tabelaArr);
    }
    
    return (
        <table>
            <thead>
                <tr>
                    <th>Descrição Alarme</th>
                    <th>Descrição Equipamento</th>
                    <th>Status do Alarme</th>
                    <th>Data Cadastro</th>
                    <th>Status</th>
                    <th>Desativar Alarme</th>
                </tr>
            </thead>
            <tbody>
                    {tabela}
            </tbody>
        </table>
    )
}