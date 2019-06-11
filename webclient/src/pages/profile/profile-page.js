import * as React from 'react';
import { connect } from 'react-redux';
import {
    getProjectsListRequest,
    updateProjectRequest,
    createProjectRequest,
    deleteProjectRequest,
    getSchemasListRequest,
    getSchemaDetailsRequest,
    updateSchemaRequest,
    createSchemaRequest,
    deleteSchemaRequest,
    getSummaryListRequest
} from './actions/profileActions';
import Grid from '@material-ui/core/Grid';
import ChromeReaderMode from '@material-ui/icons/ChromeReaderMode';
import Description from '@material-ui/icons/Description';
import AttachMoney from '@material-ui/icons/AttachMoney';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Modal from 'react-responsive-modal';
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
        schema: {},
        open: false,
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
            isModadVisible: false
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
            totalSum: ''
        });
    }

    onSchemaItemClick = (schemaItem) => {
        const { getSchemaDetailsRequest, userId } = this.props;
        const { projectId } = this.state;
        console.log(schemaItem);
        this.setState({
            isSchemasSettingsVisible: true,
            schemaId: schemaItem.id,
            isEditSchema: true,
            isSchemasListVisible: false
        });
        getSchemaDetailsRequest({ userId, projectId, schemaId: schemaItem.id });
    }

    onEditProjectClick = () => {
        this.setState({
            isProjectSettingsVisible: false,
            isProjectItemOpen: false,
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
            isSchemasListVisible: true,
            isProjectItemOpen: false
        });
        getSchemasListRequest({ userId, projectId });
    }

    onCreateProjectClick = () => {
        this.setState({
            isProjectSettingsVisible: false,
            isProjectItemOpen: false,
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
        this.setState({
            schema: {
                ...this.state.schema,
                name: newValue.target.value
            }
        });
    }

    onSchemaWallsAreaChange = (newValue) => {
        this.setState({
            schema: {
                ...this.state.schema,
                wallsArea: newValue.target.value
            }
        });
    }

    onSchemaFloorAreaChange = (newValue) => {
        this.setState({
            schema: {
                ...this.state.schema,
                floorArea: newValue.target.value
            }
        });
    }

    onSchemaCeilingAreaChange = (newValue) => {
        this.setState({
            schema: {
                ...this.state.schema,
                ceilingArea: newValue.target.value
            }
        });
    }

    onSchemaCeilingPerimeterChange = (newValue) => {
        this.setState({
            schema: {
                ...this.state.schema,
                ceilingPerimeter: newValue.target.value
            }
        });
    }

    onSchemaFloorPerimeterChange = (newValue) => {
        this.setState({
            schema: {
                ...this.state.schema,
                floorPerimeter: newValue.target.value
            }
        });
    }

    updateProject = () => {
        const { userId } = this.props;
        const { projectId, projectName } = this.state;
        this.props.updateProjectRequest({ userId, projectId, projectName });
        this.setState({
            isProjectItemOpen: true,
            isModadVisible: false
        });
    }

    createProject = () => {
        const { userId } = this.props;
        const { projectName } = this.state;
        this.props.createProjectRequest({ userId, projectName });
        this.setState({
            isProjectItemOpen: true,
            isModadVisible: false
        });
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
        const { userId, updateSchemaRequest } = this.props;
        const { projectId, schemaId, schema } = this.state;
        updateSchemaRequest({ userId, projectId, schemaId, schema });
        this.setState({
            isSchemasSettingsVisible: false,
            isSchemasListVisible: true
        })
    }

    createSchema = () => {
        const { userId, createSchemaRequest } = this.props;
        const { projectId, schema } = this.state;
        createSchemaRequest({ userId, projectId, schema });
        this.setState({
            isSchemasSettingsVisible: false,
            isSchemasListVisible: true
        })
    }

    onClose = () => {
        this.setState({
            isProjectSettingsVisible: false,
            isProjectItemOpen: false,
            isModadVisible: false,
            isEditProject: false
        })
    }

    onBack = () => {
        this.setState({
            isProjectItemOpen: true,
            isSchemasListVisible: false
        })
    }

    onCancel = () => {
        this.setState({
             isSchemasSettingsVisible: false,
            isSchemasListVisible: true
        });
    }

    onCreateNewSchemaClick = () => {
        this.setState({
            isSchemasListVisible: false,
            isEditSchema: false,
            isSchemasSettingsVisible: true
        });
    }

    deleteSchema = () => {
        const { userId, deleteSchemaRequest } = this.props;
        const { projectId, schemaId } = this.state;
        deleteSchemaRequest({ userId, projectId, schemaId });
        this.setState({
            isSchemasSettingsVisible: false,
            isSchemasListVisible: true
        });
    }

    calculateSchemaFinancials = () => {
        console.log(this.props.schemaDetails);
        return null;
    }

    onOpenModal = () => {

        const { getSummaryListRequest, userId } = this.props;
        const { projectId, schemaId } = this.state;
        getSummaryListRequest({ userId, projectId, schemaId });
        //calculateSchemaFinancials({})
        this.setState({ open: true });
      };
     
      onCloseModal = () => {
        this.setState({ open: false });
      };

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
            isProjectItemOpen,
            open
        } = this.state;
        const { projectsList, schemasList, summaryList, totalSum, schemaDetails } = this.props;
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
                        isProjectItemOpen && (
                            <div>
                                {
                                    !!projectsList.length && (
                                        <div className="projects-list">
                                            {
                                                projectsList.map(item => (
                                                    <div className="projects-item" onClick={() => this.onProjectItemClick(item)}>
                                                        <div>
                                                            <Description className="item-icon" />
                                                            <span>{item.name}</span>
                                                        </div>
                                                    </div>
                                                ))
                                            }

                                        </div>
                                    )
                                }
                                <div className="projects-list-buttons">
                                    <Button
                                        className="ok-button"
                                        size="medium"
                                        variant="contained"
                                        onClick={this.onClose}
                                    >
                                        Close
                                    </Button>
                                    <Button
                                        className="ok-button"
                                        size="medium"
                                        variant="contained"
                                        onClick={this.onCreateProjectClick}
                                    >
                                        Create New
                                    </Button>
                                    <Button
                                        className="ok-button"
                                        size="medium"
                                        variant="contained"
                                        onClick={isEditProject ? this.updateProject : this.createProject}
                                    >
                                        Next
                                    </Button>
                                </div>
                            </div>
                        )
                    }
                    {
                        isProjectSettingsVisible && (
                            <div className="project-settings">
                                <Button
                                    className="ok-button"
                                    size="medium"
                                    variant="contained"
                                    onClick={this.onEditProjectClick}
                                >
                                    Edit
                                    </Button>
                                <Button
                                    className="ok-button"
                                    size="medium"
                                    variant="contained"
                                    onClick={this.onViewSchemasClick}
                                >
                                    View Schemas
                                    </Button>
                                <Button
                                    className="ok-button"
                                    size="medium"
                                    variant="contained"
                                    onClick={this.deleteProject}
                                >
                                    Delete
                                </Button>
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
                            <div>
                                {
                                    !!schemasList.length && (
                                        <div className="projects-list">
                                            {
                                                schemasList.map(item => (
                                                    <div className="projects-item" onClick={() => this.onSchemaItemClick(item)}>
                                                        <div>
                                                            <Description className="item-icon" />
                                                            <span>{item.name}</span>
                                                        </div>
                                                    </div>
                                                ))
                                            }
                                        </div>
                                    )
                                }
                                <div className="projects-list-buttons">
                                    <Button
                                        className="ok-button"
                                        size="medium"
                                        variant="contained"
                                        onClick={this.onBack}
                                    >
                                        Back
                                    </Button>
                                    <Button
                                        className="ok-button"
                                        size="medium"
                                        variant="contained"
                                        onClick={this.onCreateNewSchemaClick}
                                    >
                                        Create New
                                    </Button>
                                    <Button
                                        className="ok-button"
                                        size="medium"
                                        variant="contained"
                                        onClick={isEditProject ? this.updateProject : this.createProject}
                                    >
                                        Next
                                    </Button>
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
                                                    id="input-with-icon-gri"
                                                    label="Schema Name"
                                                    defaultValue={isEditSchema ? schemaDetails.name : null}
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
                                                    defaultValue={isEditSchema ? schemaDetails.wallsArea : null}
                                                    onChange={this.onSchemaWallsAreaChange}
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
                                                    defaultValue={isEditSchema ? schemaDetails.floorArea : null}
                                                    onChange={this.onSchemaFloorAreaChange}
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
                                                    defaultValue={isEditSchema ? schemaDetails.ceilingArea : null}
                                                    onChange={this.onSchemaCeilingAreaChange}
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
                                                    defaultValue={isEditSchema ? schemaDetails.ceilingPerimeter : null}
                                                    onChange={this.onSchemaCeilingPerimeterChange}
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
                                                    defaultValue={isEditSchema ? schemaDetails.floorPerimeter : null}
                                                    onChange={this.onSchemaFloorPerimeterChange}
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
                                            onClick={isEditSchema ? this.updateSchema : this.createSchema}
                                        >
                                            Ok
                                        </Button>
                                    </div>
                                    <div className="schema-button">
                                        <Button
                                            className="schema-concrete-button"
                                            size="medium"
                                            variant="contained"
                                            onClick={this.onCancel}
                                        >
                                            Cancel
                                        </Button>
                                    </div>
                                    { isEditSchema && (
                                        <React.Fragment>
                                            <div className="schema-button">
                                                <Button
                                                    className="schema-concrete-button"
                                                    size="medium"
                                                    variant="contained"
                                                    onClick={this.deleteSchema}
                                                >
                                                    Delete
                                                </Button>
                                            </div>
                                            <div className="schema-button">
                                                <Button
                                                    className="schema-concrete-button"
                                                    size="medium"
                                                    variant="contained"
                                                    onClick={this.onOpenModal}
                                                >
                                                Get Summary
                                            </Button>
                                            <Modal className="sum-modal" open={open} onClose={this.onCloseModal} center>
                                            {
                                                !!schemasList.length && (
                                                    <div className="projects-list">
                                                        <div className="sum-modal-column-list">
                                                            <div className="list-column">
                                                                <div>Work name</div>
                                                            </div>
                                                            <div className="list-column">
                                                                <div>Work price</div>
                                                            </div>
                                                            <div className="list-column">
                                                                <div>Parameter value</div>
                                                            </div>
                                                            <div className="list-column">
                                                                <div>Summary</div>
                                                            </div>
                                                        </div>
                                                        <div className="sum-modal-content-list">
                                                        {
                                                            summaryList.map(item => (
                                                                <div className="">
                                                                    <div className="sum-modal-content-list-item">
                                                                        <AttachMoney className="item-icon" />
                                                                        <div>{item.workName}</div>
                                                                        <div>{item.workPrice}$/m2</div>
                                                                        <div>{item.parameterValue}m2</div>
                                                                        <div className="color-green">{item.workSum}$</div>
                                                                    </div>
                                                                </div>
                                                            ))
                                                        }
                                                        </div>
                                                        <div className="sum-modal-content-total">TOTAL: {totalSum}$</div>
                                                    </div>
                                                )
                                            }
                                            </Modal>
                                            </div>
                                        </React.Fragment>
                                    )}
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
    summaryList: store.profileReducer.summaryList,
    totalSum: store.profileReducer.totalSum
}),
    {
        getProjectsListRequest,
        updateProjectRequest,
        createProjectRequest,
        deleteProjectRequest,
        getSchemasListRequest,
        getSchemaDetailsRequest,
        updateSchemaRequest,
        createSchemaRequest,
        deleteSchemaRequest,
        getSummaryListRequest
    })(ProfilePage);