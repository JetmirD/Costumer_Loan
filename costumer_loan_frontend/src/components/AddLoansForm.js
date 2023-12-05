import { useEffect, useState } from "react";

function AddLoansForm(){
    const [amount, setAmount] = useState('')
    const [status, setStatus] = useState('')
    const [costumerId, setcostumerId] = useState('')
    const [costumer, setCostumer] = useState([])
   

    useEffect(()=>{
        fetch("https://localhost:7016/api/Costumers")
        .then(response=>response.json())
        .then(data=>{
            console.log(data)
            setCostumer(data)
        })
    }, [])


    const handleSubmit=(e)=>{
        e.preventDefault();

        const newLoan={
            amount:amount,
            status:status,
            costumerId:costumerId
        }
        fetch("https://localhost:7016/api/Loans",{
            method:"POST",
            headers:{
                'Content-Type': 'application/json'
            },
            body:JSON.stringify(newLoan)
        })
        .then(response=>{
            if(response.ok){
                console.log("Loan saved succesfully")
                return response.json()
            }
            else{
                console.log("Loan could now be saved")
            }
        })
        .then(data=>{
            console.log("Costumer saved succesfully" +data)
        })
        .catch(error=>{
            console.error("error in saving the costumer in database" + error)
        })

    }

    return(
        <form onSubmit={handleSubmit}>
            <h1>Shto Loan</h1>
        <div>
            <input type="number" value={amount} onChange={(e)=>setAmount(e.target.value)} placeholder="Loan Amount, e.g:'1000'"></input>
<br/>
            <select value={status} onChange={(e)=>setStatus(e.target.value)}>
                <option value="">Choose a status</option>
                <option value="Accepted">Accepted</option>
                <option value="Cancelled">Cancelled</option>
                <option value="Pending">Pending</option>
            </select>
            <br/>

            <select value={costumerId} onChange={(e)=>setcostumerId(e.target.value)}>
                <option value="">Choose the costumer of this loan</option>
                {costumer.map(costumers=>(
                    <option key={costumers.costumerId} value={costumers.costumerId}>
                        {costumers.name}
                    </option>
                ))}
            </select>
            <br/>

            <button type="submit">Shto Loan</button>
            <br/>
            <br/>
            <br/>

        </div>
        </form>

    )
}

export default AddLoansForm