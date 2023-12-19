import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ToDoListView from './views/ToDoLists/ToDoListView';
import 'bootstrap/dist/css/bootstrap.min.css';
import LoginView from './views/Membership/LoginView';
import SignUpView from './views/Membership/SignUpView';
import CreateView from './views/ToDoLists/CreateView';

function App() {
    return (
        <Router>

            <Routes>
                <Route path='/' element={<ToDoListView></ToDoListView> }></Route>
                <Route path='/Login' element={<LoginView></LoginView> }></Route>
                <Route path='/SignUp' element={<SignUpView></SignUpView> }></Route>
                <Route path='/ToDos/Create' element={<CreateView></CreateView>}></Route>
                <Route path='/ToDos/Update' element={<ToDoListView></ToDoListView>}></Route>
                <Route path='/ToDos/Delete' element={<ToDoListView></ToDoListView>}></Route>

            </Routes>
        </Router>
    );

   
}

export default App;