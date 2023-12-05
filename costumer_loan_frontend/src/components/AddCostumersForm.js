import { useState } from "react";

function AddCostumersForm() {
    const [name, setCostumerName] = useState(''); // Initialize with empty string
    const [isActive, setIsActive] = useState(false); // Initialize with false

    const handleSubmit = (e) => {
        e.preventDefault();

        const newCostumer = {
            name: name,
            isActive: isActive
        };

        fetch("https://localhost:7016/api/Costumers", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newCostumer)
        })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                console.log("error");
            }
        })
        .then(data => {
            console.log("Customer saved successfully: ", data);
        });
    };

    const handleIsActiveChange = (e) => {
        setIsActive(e.target.value === 'true');
    };

    return (
        <div>

            <form onSubmit={handleSubmit}>
                <h1>Shto Costumer</h1>

                <input 
                    type='text' 
                    value={name} 
                    onChange={(e) => setCostumerName(e.target.value)} 
                    required 
                    placeholder="Emri costumerit"
                /><br/>
                <select 
                    value={isActive.toString()} 
                    onChange={handleIsActiveChange}
                >
                    <option value="">Select an option</option>
                    <option value="true">True</option>
                    <option value="false">False</option>
                </select><br/>
                <button type="submit">Add</button>
                <br/><br/>  <br/><br/>
            </form>
        </div>
    );
}

export default AddCostumersForm;
