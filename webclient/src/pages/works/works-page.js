import * as React from 'react';
import { connect } from 'react-redux';
import {
    getProjectsListRequest
} from './actions/worksActions';
import './works-page.css'

export class WorksPage extends React.Component {
    state = {

    };

    componentDidMount() {
        this.props.getProjectsListRequest();
    }

    render() {
        return (
            <div className="works-page">
                {this.props.worksList}
            </div>
        )
    }
}

export default connect(store => ({
    worksList: store.worksReducer.worksList,
}),
    {
        getProjectsListRequest
    })(WorksPage);
