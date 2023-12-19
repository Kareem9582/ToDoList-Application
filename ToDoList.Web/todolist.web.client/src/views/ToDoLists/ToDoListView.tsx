import { useEffect, useState } from 'react';
import PermissionGate from '../../components/PermissionGate/PermissionGate';
import NoPermissionsView from '../NoPermissionsView/NoPermissionsView';
import { GetDoToItems } from '../../services/ToDoListService';
import { ToDoItem } from '../../Types/ToDoItem';
import { Link } from 'react-router-dom';

const ToDoListView = (): JSX.Element => {
    const [items, setItems] = useState<ToDoItem[]>();

    useEffect(() => {
        GetData();
    }, []);

    const contents = items === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Is Completed</th>
                    <th>Completion Date</th>
                </tr>
            </thead>
            <tbody>
                {items.map(item =>
                    <tr key={item.id}>
                        <td>{item.title}</td>
                        <td>{item.description}</td>
                        <td>{item.isCompleted}</td>
                        <td>{item.completionDate}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <PermissionGate fallback={
            <NoPermissionsView
                actionText={
                    <span>
                        <strong>TO DO List</strong>
                    </span>
                }
            >
            </NoPermissionsView>
        }>
            <div className='container'>
                <div className='d-flex'>
                    <Link to='/SignUp' className='btn btn-info'>Create</Link>
                </div>
            </div>
            <div>
                <h1 id="tabelLabel">To Do List</h1>
                {contents}
            </div>
        </PermissionGate>
    );

    async function GetData() {
        const response = await GetDoToItems();
        const data = await response;
        setItems(data);
        
    }
}


export default ToDoListView;