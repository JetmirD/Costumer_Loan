import logo from './logo.svg';
import './App.css';
import { useEffect, useState } from 'react';
import AddCostumersForm from'./components/AddCostumersForm'
import AddLoansForm from './components/AddLoansForm'
function App() {

  const [costumers, setCostumers] = useState([])
  const[loans, setLoans] = useState([])
  const [filterCostumer, setFilterCostumer] = useState('');
const [deleteID, setDeleteID] = useState('')

  const filterLoansByCostumer =async()=>{
      const response = await fetch(`https://localhost:7016/api/Loans/filterByCostumer?Costumeri=${filterCostumer}`)
      const data = await response.json();
      setLoans(data);
  }

const deleteAuthor = async()=>{
  const response = await fetch(`https://localhost:7016/api/Costumers?id=${deleteID}`,{
    method:'DELETE',
    headers: {
      'Content-Type': 'application/json'
  },
    body:JSON.stringify({
      id: deleteID
    })
  })
  if (response.ok) {
    alert("Successfully Deleted the costumer")
} else {
    console.log("error");
}
}
  useEffect(()=>{
    
    fetch("https://localhost:7016/api/Costumers")
    .then(response=>response.json())
    
    .then(data=>{
      setCostumers(data);
    })
    
    .catch(error=>{
      console.error("Error fethcing data from database"+error);
    })


    fetch("https://localhost:7016/api/Loans")
    .then(response=>response.json())
    .then(data=>{
      setLoans(data)
    })
    .catch(error=>{
      console.error("Error fetching database" +error)
    })
  }, [])

  return (
    <div className="App">
      <header className="App-header">
    <h1>DELETE A COSTUMER</h1>
    <input type="number" placeholder='type a ID' value={deleteID} onChange={e=>setDeleteID(e.target.value)}/>
    <button type='submit' onClick={deleteAuthor}>Fshije</button>
      
        
      <h1>Costumers</h1>
      <ul>
        {costumers.map(costumer=>(
          <li key={costumer.costumerId}>
              {costumer.name} eshte "{costumer.isActive?"Aktiv":"Jo Aktiv"}" ne databaze
          </li>
        ))}
      </ul>

      <h4>Filtro kredite sipas costumereve</h4>
      <input type="text" value={filterCostumer} onChange={e=>setFilterCostumer(e.target.value)} placeholder='Sheno konsumator si "Jetmir"'/>
      <button type='submit' onClick={filterLoansByCostumer}>Filtro</button>


      <h1>Loans</h1>
        <ul>
          {loans.map(loan=>(
            <li key={loan.loanId}>
              Costumer: "{loan.costumer.name}" me ID:"{loan.costumer.costumerId}" ka kredi me shumen: {loan.amount}$ <span style={{color:'red'}}>*Statusi i kredise i {loan.status}*</span>
            </li>
          ))}
        </ul>

        <AddCostumersForm />

<AddLoansForm/>
      </header>
    </div>
  );
}

export default App;
