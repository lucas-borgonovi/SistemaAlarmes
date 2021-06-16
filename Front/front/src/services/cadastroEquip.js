import axios from 'axios';

export default async function postEquip(data)
{
    console.log(data)
    return axios
        .post("https://localhost:44320/api/Equipamentos",data)
        .then(response=>{
            console.log(response.data)
            return response.data
        })

}