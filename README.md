# 👨‍👩‍👧‍👦 Family Simulation App

Application ASP.NET Core + React pour simuler des générations d'une famille. Je vais pas mentir j'ai perdu fois dans le projet à la moitier, le sujet est cool mais c'est genre la 15eme + API qu'on fait pour l'école

## 📦 Contenu

- **Backend** : API REST ASP.NET Core (.NET 8)
  - Endpoint sécurisé avec JWT
  - Swagger documenté

- **Frontend** : React + Vite
  - Connexion avec JWT
  - Simulation de familles et affichage JSON

## 🚀 Lancer le projet

### Backend

#### Installation

cd FamilySimulationApi
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

#### lancement

cd FamilySimulationApi
dotnet run

📍 Swagger dispo sur : http://localhost:7271/swagger (possiblement le port sera faux, mais dans tout les cas le swagger est lancé directement par le serveur, si ce n'est pas le même nombre il faudra changer dans le front le veryBasicFamilySim\family-sim-ui\src\app.jsx la ligne const API_URL = "https://localhost:7271"; avec le bon port)

### Frontend

cd family-sim-ui
npm install
npm run dev
📍 Frontend dispo sur : http://localhost:5173

## 🧪 Identifiants de test
Username	testuser
Password	Test@123

## 🔐 Authentification
POST /api/auth/login → retourne un token JWT
POST /api/family/simulate → nécessite un token (Bearer ...)