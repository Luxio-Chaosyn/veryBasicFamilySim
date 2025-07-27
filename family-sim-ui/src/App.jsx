import { useState } from 'react'

const API_URL = "https://localhost:7271";

function App() {
  const [token, setToken] = useState("");
  const [form, setForm] = useState({ generations: 3, childrenPerFamily: 2 });
  const [result, setResult] = useState(null);
  const [login, setLogin] = useState({ username: "testuser", password: "Test@123" });

  const handleLogin = async () => {
    const res = await fetch(`${API_URL}/api/auth/login`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(login),
    });

    if (res.ok) {
      const data = await res.json();
      setToken(data.token);
    } else {
      alert("Échec de la connexion");
    }
  };

  const handleGenerate = async () => {
    const res = await fetch(`${API_URL}/api/family/simulate`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${token}`,
      },
      body: JSON.stringify(form),
    });

    if (res.ok) {
      const data = await res.json();
      setResult(data);
    } else {
      alert("Erreur lors de la génération");
    }
  };

  return (
    <div className="p-6 max-w-3xl mx-auto space-y-6">
      <h1 className="text-2xl font-bold">Family Simulator</h1>

      {!token ? (
        <div className="space-y-2">
          <h2 className="text-xl font-semibold">Connexion</h2>
          <input
            placeholder="Username"
            value={login.username}
            onChange={e => setLogin({ ...login, username: e.target.value })}
            className="border p-2 w-full"
          />
          <input
            placeholder="Password"
            type="password"
            value={login.password}
            onChange={e => setLogin({ ...login, password: e.target.value })}
            className="border p-2 w-full"
          />
          <button onClick={handleLogin} className="bg-blue-500 text-white px-4 py-2 rounded">
            Se connecter
          </button>
        </div>
      ) : (
        <div className="space-y-4">
          <h2 className="text-xl font-semibold">Simulation</h2>
          <input
            type="number"
            placeholder="Generations"
            value={form.generations}
            onChange={e => setForm({ ...form, generations: parseInt(e.target.value) })}
            className="border p-2 w-full"
          />
          <input
            type="number"
            placeholder="Children Per Family"
            value={form.childrenPerFamily}
            onChange={e => setForm({ ...form, childrenPerFamily: parseInt(e.target.value) })}
            className="border p-2 w-full"
          />
          <button onClick={handleGenerate} className="bg-green-600 text-white px-4 py-2 rounded">
            Générer Famille
          </button>

          {result && (
            <pre className="bg-gray-100 p-4 rounded overflow-x-auto text-sm">
              {JSON.stringify(result, null, 2)}
            </pre>
          )}
        </div>
      )}
    </div>
  );
}

export default App;
