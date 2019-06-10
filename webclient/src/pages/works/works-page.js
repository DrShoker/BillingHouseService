import * as React from 'react';
import { connect } from 'react-redux';
import {
    getWorksListRequest,
    getCompanyWorksListRequest,
    getWorkDetailsRequest,
    setCompWorkToSchemaRequest
} from './actions/worksActions';
import { getProjectsListRequest, getSchemasListRequest } from './../profile/actions/profileActions'
import Grid from '@material-ui/core/Grid';
import ChromeReaderMode from '@material-ui/icons/ChromeReaderMode';
import AttachMoney from '@material-ui/icons/AttachMoney';
import Extension from '@material-ui/icons/Extension';
import Build from '@material-ui/icons/Build';
import KeyboardBackspace from '@material-ui/icons/KeyboardBackspace';
import Description from '@material-ui/icons/Description';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import SimpleModal from './work-modal';


import './works-page.css'

export class WorksPage extends React.Component {
    state = {
        searchField: '',
        isWorkOpen: false,
        workId: '',
        compWorkId: '',
        isProjectModalOpen: false,
        isWorksListOpen: true,
        isSchemasModelOpen: false,
    };

    componentDidMount() {
        this.props.getWorksListRequest();
        console.log(this.props);
    }

    static getDerivedStateFromProps(nextProps, prevState) {
        const { workDetails } = nextProps;
        console.log(workDetails);
        return null;
    }

    onWorkItemClick = (workId) => {
        this.setState({
            isWorkOpen: true,
            isWorksListOpen: false
        });
        this.props.getWorkDetailsRequest({ workId });
        this.props.getCompanyWorksListRequest({ workId });
    }

    onBack = () => {
        this.setState({
            isWorkOpen: false
        });
    }

    onAddToSchemaClick = (compWorkId) => {
        const { userId, getProjectsListRequest } = this.props;
        getProjectsListRequest({ userId });
        this.setState({
            isProjectModalOpen: true,
            isWorkOpen: false,
            compWorkId: compWorkId
        });
    }

    onProjectItemClick = (projectId) => {
        const { userId, getSchemasListRequest } = this.props;
        this.setState({
            isSchemasModelOpen: true,
            isProjectModalOpen: false,
        });
        getSchemasListRequest({ userId, projectId });
    }

    onSchemaItemClick = (schemaId) => {
        const { setCompWorkToSchemaRequest } = this.props;
        setCompWorkToSchemaRequest({ workId: this.state.compWorkId, schemaId });
        this.setState({
            isSchemasModelOpen: false,
            isWorksListOpen: true,
        });
    }

    render() {
        const { worksList, compWorksList, workDetails, projectsList, schemasList } = this.props;
        const { isWorkOpen, isProjectModalOpen, isWorksListOpen, isSchemasModelOpen } = this.state;
        return (
            <div className="works-page">
                {isWorkOpen && (<KeyboardBackspace />)}
                <div className="works-page-title">
                    <span>Construction Works</span>
                </div>
                {
                    isWorksListOpen && (
                        <div className="works-page-toolbar">
                            <div className="project-modal-field">
                                <Grid container spacing={1} alignItems="flex-end">
                                    <Grid item>
                                        <ChromeReaderMode />
                                    </Grid>
                                    <Grid item>
                                        <TextField
                                            id="input-with-icon-grid"
                                            placeholder="SearchWorks"
                                            onChange={this.onProjectNameChange}
                                        />
                                    </Grid>
                                </Grid>
                            </div>
                        </div>
                    )
                }
                {isWorksListOpen && (
                    <div className="works-page-content">
                        {
                            !!worksList.length && (
                                <div className="works-content-list">
                                    {
                                        worksList.map(item => (
                                            <div className="works-item">
                                                <div className="works-item-content">
                                                    <Build className="works-item-icon" />
                                                    <span>{item.name}</span>
                                                    <div className="const-works-button">
                                                        {/* <AttachMoney />
                                                <span>Details</span> */}
                                                        <Button
                                                            className="works-button"
                                                            size="medium"
                                                            variant="contained"
                                                            onClick={() => this.onWorkItemClick(item.id)}
                                                        >
                                                            Details
                                                </Button>                                            </div>
                                                </div>
                                            </div>
                                        ))
                                    }
                                </div>
                            )
                        }
                    </div>
                )}
                {isWorkOpen && (
                    <div className="work-details">
                        <div className="work-info">
                            <div className="work-field">
                                <span>{workDetails.name}</span>
                            </div>
                            <div className="work-type">
                                <div><Extension /> Type: {!!workDetails.typeOfWorks && (workDetails.typeOfWorks.name)}</div>
                            </div>
                            <div className="work-description">
                                <div><ChromeReaderMode /> Description: {workDetails.description}</div>
                            </div>
                        </div>
                        <div className="comp-work-list-header">
                            <span>Work in companies:</span>
                        </div>
                        <div className="comp-works-content-list">
                            {
                                compWorksList.map(item => (
                                    <div className="works-item">
                                        <div className="works-item-content">
                                            <Build className="works-item-icon" />
                                            <span>Company: {item.company.name}</span>
                                            <span>Price: {item.price}$</span>
                                            <div className="const-works-button">
                                                <Button
                                                    className="works-button"
                                                    size="medium"
                                                    variant="contained"
                                                    onClick={() => this.onAddToSchemaClick(item.id)}
                                                >
                                                    Add to schema
                                        </Button>
                                            </div>
                                        </div>
                                    </div>
                                ))
                            }
                        </div>
                    </div>
                )}
                {
                    isProjectModalOpen && (
                        !!projectsList.length && (
                            <div className="work-projects-list">
                                <div className="work-projects-list-header">
                                    <span>Choose project:</span>
                                </div>
                                {
                                    projectsList.map(item => (
                                        <div className="work-projects-item" onClick={() => this.onProjectItemClick(item.id)}>
                                            <div>
                                                <Description className="item-icon" />
                                                <span>{item.name}</span>
                                            </div>
                                        </div>
                                    ))
                                }

                            </div>
                        )
                        //<SimpleModal />
                    )
                }
                {
                    isSchemasModelOpen && (
                        !!schemasList.length && (
                            <div className="work-projects-list">
                                <div className="work-projects-list-header">
                                    <span>Choose schema:</span>
                                </div>
                                {
                                    schemasList.map(item => (
                                        <div className="work-projects-item" onClick={() => this.onSchemaItemClick(item.id)}>
                                            <div>
                                                <Description className="item-icon" />
                                                <span>{item.name}</span>
                                            </div>
                                        </div>
                                    ))
                                }

                            </div>
                        )
                        //<SimpleModal />
                    )
                }
            </div>
        )
    }
}

export default connect(store => ({
    worksList: store.worksReducer.worksList,
    compWorksList: store.worksReducer.compWorksList,
    workDetails: store.worksReducer.workDetails,
    userId: store.authReducer.id,
    projectsList: store.profileReducer.projectsList,
    schemasList: store.profileReducer.schemasList,
}),
    {
        getProjectsListRequest,
        getCompanyWorksListRequest,
        getWorkDetailsRequest,
        getWorksListRequest,
        getSchemasListRequest,
        setCompWorkToSchemaRequest
    })(WorksPage);
