import axios from 'axios';

export default async function nomeEquip()
{
    return axios
        .get("https://localhost:44320/api/Equipamentos")
        .then(response=>{
            return response.data
        })

}