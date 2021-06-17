import axios from 'axios';

export default async function postEquip(data)
{

    return axios
        .post("https://localhost:44320/api/Equipamentos",data)
        .then(response=>{
            return response.data
        })

}