import React, {useEffect,useState} from 'react';
import apiAllAlarmes from '../../services/tabelaAlarmes';
import apiUpdateAlarmes from '../../services/updateAlarme';
import handleBool from '../../utils/handleBool';
import { DataGrid } from '@material-ui/data-grid';
import Button from '@material-ui/core/Button';
import formatJson from '../../utils/formatJson';
import handleStatusTable from '../../utils/handleStatusTable';



export default function Visualizacao(){

    const[rows,setRows] = useState([]);

    const columns = [
        {field: 'col1', headerName: 'Descrição Alarme', width: 300},
        {field: 'col2', headerName: 'Classificação Alarme', width: 300},
        {field: 'col3', headerName: 'Data de Cadastro', width: 300},
        {field: 'col4', headerName: 'Equipamento', width: 300},
        {field: 'col5', headerName: 'Status', width: 300},
        {
            field: 'col6', 
            headerName: 'Desativar/Ativar', 
            width: 300,
            disableClickEventBubbling: true,
            renderCell: (params)=>{
           
                const onClick = async () => {

                    let selectedRow = params.row;

                    let statusTable = handleStatusTable(selectedRow.col5)

                    statusTable === true ? statusTable = false : statusTable = true;

                    const status = formatJson(statusTable);

                    await apiUpdateAlarmes(selectedRow.id,status);
                    
                    await apiAllAlarmes()
                        .then((res)=>{
                            formatRows(res);
                        })

                   
                  };

                return <Button onClick={onClick}>Ação</Button>
            }
            
        }
    ]


    useEffect( ()=>{
            
        async function fetchData(){

            await apiAllAlarmes()
                .then((res)=>{
                    formatRows(res)
                })
        }

        fetchData();
 

    },[])

    function formatRows(alarms){
        const arrayRows = [];
        alarms.map((item)=>{

            item.Status = handleBool(item.Status);

            let row = {
                id: item.id,
                col1:item.Descricao,
                col2:item.Classificacao,
                col3:item.Data,
                col4:item.Nome,
                col5:item.Status,
                col6:"teste"
            }

            arrayRows.push(row);
        })

        setRows(arrayRows);

    }

    return(
        <div style={{ height: 300, width: '100%' }}>

            <DataGrid 
            rows={rows} 
            columns={columns}    
            />

        </div>
    )
}