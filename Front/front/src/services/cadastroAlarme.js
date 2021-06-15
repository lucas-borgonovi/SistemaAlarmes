import axios from 'axios';

export default async function postAlarme(data)
{
    return axios
        .post("https://localhost:44320/api/Alarmes",data)
        .then(response=>{
            console.log(response.data)
            return response.data
        })

}