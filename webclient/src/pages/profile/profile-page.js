import * as React from 'react';
import { connect } from 'react-redux';
import {
    getProjectsListRequest,
    updateProjectRequest,
    createProjectRequest,
    deleteProjectRequest,
    getSchemasListRequest,
    getSchemaDetailsRequest
} from './actions/profileActions';
import Grid from '@material-ui/core/Grid';
import ChromeReaderMode from '@material-ui/icons/ChromeReaderMode';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import './profile-page.css'

export class ProfilePage extends React.Component {

    state = {
        isProjectItemOpen: false,
        isSettingsItemOpen: false,
        isProjectSettingsVisible: false,
        projectName: '',
        projectId: '',
        isModadVisible: false,
        modalTitle: '',
        isEditProject: false,
        isEditSchema: false,
        isSchemasSettingsVisible: false,
        isSchemasListVisible: false,
        schemaId: '',
        schemaDetails: this.props.schemaDetails || {}
    };

    // static getDerivedStateFromProps(nextProps, prevState) {
    //     const { schemaDetails } = nextProps;
    //     if (JSON.stringify(prevState.schemaDetails) !== JSON.stringify(schemaDetails)) {
    //         console.log(schemaDetails);
    //         return { schemaDetails: nextProps.schemaDetails }
    //     }
    //     else return null;
    // }

    onProjectsItemClick = () => {
        const { userId, getProjectsListRequest } = this.props;
        this.setState({
            isProjectItemOpen: true,
            isSettingsItemOpen: false,
        }, () => { getProjectsListRequest({ userId }); });
    };

    onProjectItemClick = (projectItem) => {
        this.setState({
            isProjectSettingsVisible: true,
            isSchemasListVisible: false,
            isSchemasSettingsVisible: false,
            projectName: projectItem.name,
            projectId: projectItem.id,
            isModadVisible: false,
        });
    }

    onSchemaItemClick = (schemaItem) => {
        const { getSchemaDetailsRequest, userId } = this.props;
        const { projectId } = this.state;
        console.log(schemaItem);
        this.setState({
            isSchemasSettingsVisible: true,
            schemaId: schemaItem.id,
            isEditSchema: true
        });
        getSchemaDetailsRequest({ userId, projectId, schemaId: schemaItem.id });
    }

    onEditProjectClick = () => {
        this.setState({
            isProjectSettingsVisible: false,
            isModadVisible: true,
            modalTitle: 'Edit Project',
            isEditProject: true
        });
    }

    onViewSchemasClick = () => {
        const { userId, getSchemasListRequest } = this.props;
        const { projectId } = this.state;
        this.setState({
            isProjectSettingsVisible: false,
            isSchemasListVisible: true
        });
        getSchemasListRequest({ userId, projectId });
    }

    onCreateProjectClick = () => {
        this.setState({
            isProjectSettingsVisible: false,
            isModadVisible: true,
            modalTitle: 'Create Project',
            isEditProject: false
        });
    }

    onProjectNameChange = (newValue) => {
        console.log(newValue.target.value);
        this.setState({
            projectName: newValue.target.value
        });
    }

    onSchemaNameChange = (newValue) => {
        console.log(newValue.target.value);
        this.setState(prevState => ({
            // schemaDetails: {    
            //     ...prevState.schemaDetails,
            //     name: newValue.target.value
            // }
        }), () =>console.log(newValue.target.value));
    }

    updateProject = () => {
        const { userId } = this.props;
        const { projectId, projectName } = this.state;
        this.props.updateProjectRequest({ userId, projectId, projectName });
    }

    createProject = () => {
        const { userId } = this.props;
        const { projectName } = this.state;
        this.props.createProjectRequest({ userId, projectName });
    }

    deleteProject = () => {
        const { userId } = this.props;
        const { projectId } = this.state;
        this.props.deleteProjectRequest({ userId, projectId });
        this.setState({
            isProjectSettingsVisible: false,
        })
    }

    updateSchema = () => {
        const { userId } = this.props;
        const { projectId, schemaId } = this.state;

    }

    render() {
        const {
            isProjectSettingsVisible,
            isModadVisible,
            modalTitle,
            projectName,
            isEditProject,
            isSchemasSettingsVisible,
            isSchemasListVisible,
            isEditSchema,
            schemaDetails,
        } = this.state;
        const { projectsList, schemasList } = this.props;
        return (
            <div className="profile-page">
                <div className="profile-list">
                    <div className="profile-list-header">
                        <span>Profile Menu</span>
                    </div>
                    <div className="profile-list-content">
                        <div className="profile-list-item" onClick={this.onProjectsItemClick}>
                            <span>Projects</span>
                        </div>
                        <div className="profile-list-item">
                            <span>Settings</span>
                        </div>
                    </div>
                </div>
                <div className="profile-area">
                    {
                        !!projectsList.length && (
                            <div className="projects-list">
                                {
                                    projectsList.map(item => (
                                        <div className="projects-item" onClick={() => this.onProjectItemClick(item)}>
                                            <span>{item.name}</span>
                                        </div>
                                    ))
                                }
                                <div className="projects-item">
                                    <span>Next</span>
                                </div>
                                <div className="projects-item" onClick={this.onCreateProjectClick}>
                                    <span>Create new</span>
                                </div>
                            </div>
                        )
                    }
                    {
                        isProjectSettingsVisible && (
                            <div className="project-settings">
                                <div className="project-settings-item" onClick={this.onViewSchemasClick}>
                                    <span>View Schemas</span>
                                </div>
                                <div className="project-settings-item" onClick={this.onEditProjectClick}>
                                    <span>Edit Project</span>
                                </div>
                                <div className="project-settings-item" onClick={this.deleteProject}>
                                    <span>Delete Project</span>
                                </div>
                            </div>
                        )
                    }
                    {
                        isModadVisible && (
                            <div className="project-modal">
                                <span>{modalTitle}</span>
                                <div className="project-modal-field">
                                    <Grid container spacing={1} alignItems="flex-end">
                                        <Grid item>
                                            <ChromeReaderMode />
                                        </Grid>
                                        <Grid item>
                                            <TextField
                                                id="input-with-icon-grid"
                                                label="Project Name"
                                                defaultValue={projectName}
                                                onChange={this.onProjectNameChange}
                                            />
                                        </Grid>
                                    </Grid>
                                </div>
                                <div className="project-modal-button">
                                    <Button
                                        className="ok-button"
                                        size="medium"
                                        variant="contained"
                                        onClick={isEditProject ? this.updateProject : this.createProject}
                                    >
                                        Ok
                                        </Button>
                                </div>
                            </div>
                        )
                    }
                    {
                        isSchemasListVisible && (
                            <div className="schemas-list">
                                {
                                    !!schemasList.length && (
                                        schemasList.map(item => (
                                            <div className="schemas-item" onClick={() => this.onSchemaItemClick(item)}>
                                                <span>{item.name}</span>
                                            </div>
                                        ))
                                    )
                                }
                                <div className="schemas-item">
                                    <span>Create new</span>
                                </div>
                            </div>
                        )
                    }
                    {
                        isSchemasSettingsVisible && (
                            <div className="schema-settings">
                                <div className="schema-title">
                                    <span>{isEditSchema ? "Edit Schema" : "Create Schema"}</span>
                                </div>
                                <div className="schema-content">
                                    <div className="schema-content-field">
                                        <Grid container spacing={1} alignItems="flex-end">
                                            <Grid item>
                                                <ChromeReaderMode />
                                            </Grid>
                                            <Grid item>
                                                <TextField
                                                    id="input-with-icon-grid"
                                                    label="Schema Name"
                                                    defaultValue=''
                                                    onChange={this.onSchemaNameChange}
                                                />
                                            </Grid>
                                        </Grid>
                                    </div>
                                    <div className="schema-content-field">
                                        <Grid container spacing={1} alignItems="flex-end">
                                            <Grid item>
                                                <ChromeReaderMode />
                                            </Grid>
                                            <Grid item>
                                                <TextField
                                                    id="input-with-icon-grid"
                                                    label="Walls Area"
                                                    onChange={this.onProjectNameChange}
                                                />
                                            </Grid>
                                        </Grid>
                                    </div>
                                    <div className="schema-content-field">
                                        <Grid container spacing={1} alignItems="flex-end">
                                            <Grid item>
                                                <ChromeReaderMode />
                                            </Grid>
                                            <Grid item>
                                                <TextField
                                                    id="input-with-icon-grid"
                                                    label="Floor Area"
                                                    onChange={this.onProjectNameChange}
                                                />
                                            </Grid>
                                        </Grid>
                                    </div>
                                    <div className="schema-content-field">
                                        <Grid container spacing={1} alignItems="flex-end">
                                            <Grid item>
                                                <ChromeReaderMode />
                                            </Grid>
                                            <Grid item>
                                                <TextField
                                                    id="input-with-icon-grid"
                                                    label="Ceiling Area"
                                                    onChange={this.onProjectNameChange}
                                                />
                                            </Grid>
                                        </Grid>
                                    </div>
                                    <div className="schema-content-field">
                                        <Grid container spacing={1} alignItems="flex-end">
                                            <Grid item>
                                                <ChromeReaderMode />
                                            </Grid>
                                            <Grid item>
                                                <TextField
                                                    id="input-with-icon-grid"
                                                    label="Ceiling Perimeter"
                                                    onChange={this.onProjectNameChange}
                                                />
                                            </Grid>
                                        </Grid>
                                    </div>
                                    <div className="schema-content-field">
                                        <Grid container spacing={1} alignItems="flex-end">
                                            <Grid item>
                                                <ChromeReaderMode />
                                            </Grid>
                                            <Grid item>
                                                <TextField
                                                    id="input-with-icon-grid"
                                                    label="Floor Perimeter"
                                                    onChange={this.onProjectNameChange}
                                                />
                                            </Grid>
                                        </Grid>
                                    </div>
                                </div>
                                <div className="schema-buttons">
                                    <div className="schema-button">
                                        <Button
                                            className="schema-concrete-button"
                                            size="medium"
                                            variant="contained"
                                            onClick={isEditProject ? this.updateProject : this.createProject}
                                        >
                                            Edit
                                        </Button>
                                    </div>
                                    <div className="schema-button">
                                        <Button
                                            className="schema-concrete-button"
                                            size="medium"
                                            variant="contained"
                                            onClick={isEditProject ? this.updateProject : this.createProject}
                                        >
                                            Works
                                        </Button>
                                    </div>
                                </div>
                            </div>
                        )
                    }
                </div>
            </div>
        );
    }
}

export default connect(store => ({
    userId: store.authReducer.id,
    projectsList: store.profileReducer.projectsList,
    schemasList: store.profileReducer.schemasList,
    schemaDetails: store.profileReducer.schemaDetails,
}),
    {
        getProjectsListRequest,
        updateProjectRequest,
        createProjectRequest,
        deleteProjectRequest,
        getSchemasListRequest,
        getSchemaDetailsRequest
    })(ProfilePage);