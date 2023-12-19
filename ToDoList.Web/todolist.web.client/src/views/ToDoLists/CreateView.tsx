import { Link, useNavigate } from "react-router-dom";
import PermissionGate from "../../components/PermissionGate/PermissionGate";
import NoPermissionsView from "../NoPermissionsView/NoPermissionsView";
import { ToDoItem } from "../../Types/ToDoItem";
import { useState } from "react";
import { CreateItem } from "../../services/ToDoListService";

const CreateView = (): JSX.Element => {
    const [error, setError] = useState<string>();
    const navigate = useNavigate();
    const [item, SetItem] = useState<ToDoItem>({
        title: '',
        description: ''
    });

    const handleFormSubmit = async (event: any) => {
        event.preventDefault();
        const result = await CreateItem(item);
        if ("tokenType" in result) {
            navigate('/');
        }
        else {
            console.log(result);
            setError('Something is Wrong');
        }

    }

    return (
        <PermissionGate fallback={
            <NoPermissionsView
                actionText={
                    <span>
                        <strong>Create To do Item</strong>
                    </span>
                }
            >
            </NoPermissionsView>
        }>
            <div className='w-100 vh-100 justify-content-center align-items-center' >
                <div className='border bg-secondary text-white p-5'>
                    <form onSubmit={handleFormSubmit}>
                        <div className='mb-3'>
                            <label htmlFor='title'>Title:</label>
                            <input type='text' name='title' className='form-control' placeholder='Enter Title' required
                                onChange={e => SetItem({ ...item, title: e.target.value })} />
                        </div>
                        <div className='mb-3'>
                            <label htmlFor='description'>Description:</label>
                            <input type='text' name='description' className='form-control' placeholder='Enter Description' required
                                onChange={e => SetItem({ ...item, description: e.target.value })} />
                        </div>
                        <div className='mb-3'>
                            <button className='btn btn-info'>Login</button>
                        </div>
                        <div className='mb-3' hidden={error ? false : true}>
                            <div className='alert alert-danger' role='alert'>{error}</div>
                        </div>
                    </form>
                </div>
                <p>Not a Member?!!  <Link to='/SignUp'>Sign Up</Link></p>
            </div>
        </PermissionGate>
    );
}

export default CreateView;
