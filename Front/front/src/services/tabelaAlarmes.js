import axios from 'axios';

export default async function tabelaAlarmes()
{
    return axios
        .get("https://localhost:44320/api/Alarmes")
        .then(response=>{
            console.log(response.data)
            return response.data
        })

}